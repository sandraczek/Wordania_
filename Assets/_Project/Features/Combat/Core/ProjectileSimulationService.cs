using System.Collections.Generic;
using Wordania.Core.Combat;
using Wordania.Features.Combat.Data;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using System;
using VContainer.Unity;

namespace Wordania.Features.Combat.Core
{
    public sealed class ProjectileSimulationService : IProjectileSimulationService, IDisposable, ITickable
    {   
        public event Action<ProjectileView> OnProjectileDeath;
        // Unmanaged World (Data for the CPU)
        private NativeList<ProjectileRuntimeData> _projectilesData = new NativeList<ProjectileRuntimeData>(1000, Allocator.Persistent);
        
        // Managed World (Views for the GPU/Player)
        // Indexes strictly match _projectilesData
        private readonly List<ProjectileView> _projectileViews = new();

        public void Dispose()
        {
            // CRITICAL: Native memory MUST be disposed manually, or you get memory leaks!
            if (_projectilesData.IsCreated)
            {
                _projectilesData.Dispose();
            }
        }

        public void Register(ref ProjectileRuntimeData runtimeData, ProjectileView view)
        {
            _projectilesData.Add(runtimeData);
            _projectileViews.Add(view);
        }

        public void Tick()
        {
            if (_projectilesData.Length == 0) return;

            // 1. Schedule the Job across multiple CPU cores
            var job = new ProjectileSimulationJob
            {
                DeltaTime = Time.deltaTime,
                Projectiles = _projectilesData.AsArray()
            };

            // Schedule parallel job with batch size of 64
            JobHandle handle = job.Schedule(_projectilesData.Length, 64);
            
            // 2. Wait for completion (In a more advanced setup, you'd wait in LateUpdate)
            handle.Complete();

            // 3. Sync Views and Handle Deaths (Back on the main thread)
            SyncViewsAndCleanup();
        }

        private void SyncViewsAndCleanup()
        {
            // We iterate backwards to safely remove elements using Swap-Back
            for (int i = _projectilesData.Length - 1; i >= 0; i--)
            {
                ProjectileRuntimeData data = _projectilesData[i];
                ProjectileView view = _projectileViews[i];

                if (!data.IsActive)
                {
                    // Death Resolution: Return to Object Pool
                    OnProjectileDeath?.Invoke(view);

                    // O(1) Removal Algorithm: Swap with the last element and remove last
                    RemoveProjectileAt(i);
                }
                else
                {
                    // Sync Transform for rendering
                    view.transform.position = new Vector3(data.CurrentPosition.x, data.CurrentPosition.y, 0f);
                    
                    // Optional: Update rotation based on velocity (if arrows/rockets)
                    UpdateViewRotation(view, data.Velocity);
                }
            }
        }

        private void RemoveProjectileAt(int index)
        {
            int lastIndex = _projectilesData.Length - 1;

            // Overwrite the current dead element with the last valid element
            _projectilesData[index] = _projectilesData[lastIndex];
            _projectileViews[index] = _projectileViews[lastIndex];

            // Shrink the lists by 1 (O(1) operation, no memory shifting)
            _projectilesData.RemoveAtSwapBack(index);
            _projectileViews.RemoveAt(lastIndex); 
        }

        private void UpdateViewRotation(ProjectileView view, float2 velocity)
        {
            if (math.lengthsq(velocity) > 0.01f)
            {
                float angle = math.atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
                view.transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }
}