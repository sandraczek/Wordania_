using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using Wordania.Core.Gameplay;
using Wordania.Features.Combat.Data;
using Wordania.Features.Combat.Signals;

namespace Wordania.Features.Combat.Core
{
    [BurstCompile(CompileSynchronously = true)]
    public struct ProjectileSimulationJob : IJobParallelFor
    {
        [ReadOnly] public float DeltaTime;
        [ReadOnly] public NativeArray<TargetAABB> Targets;
    
        [WriteOnly] public NativeQueue<ProjectileHitEvent>.ParallelWriter HitEventsQueue;
        
        public NativeArray<ProjectileRuntimeData> Projectiles;

        public void Execute(int index)
        {
            ProjectileRuntimeData data = Projectiles[index];
            
            if (!data.IsActive) return;

            // 1. Handle Lifetime
            data.RemainingLifetime -= DeltaTime;
            if (data.RemainingLifetime <= 0f)
            {
                data.IsActive = false;
                Projectiles[index] = data;
                return;
            }

            data.PreviousPosition = data.CurrentPosition;
            data.Velocity.y -= 9.81f * data.GravityMultiplier * DeltaTime;
            data.CurrentPosition += data.Velocity * DeltaTime;

            // 2. Collisions
            bool hasHit = false;

            for (int i = 0; i < Targets.Length; i++)
            {
                TargetAABB target = Targets[i];

                if (IsPointInsideAABB(data.CurrentPosition, target))
                {
                    HitEventsQueue.Enqueue(new ProjectileHitEvent
                    {
                        ProjectileDataId = data.DataId,
                        HitEntityId = target.EntityInstanceId,
                        HitPosition = data.CurrentPosition,
                        DamageMultiplier = data.DamageMultiplier,
                        InstigatorId = data.InstigatorId
                    });

                    hasHit = true;
                    break;
                }
            }

            // 3. Resolution
            if (hasHit)
            {
                data.RemainingPierces--;
                if (data.RemainingPierces <= 0)
                {
                    data.IsActive = false; // Kill projectile
                }
            }

            Projectiles[index] = data;
        }

        private readonly bool IsPointInsideAABB(float2 point, TargetAABB aabb)
        {
            return point.x >= aabb.Min.x && point.x <= aabb.Max.x &&
                point.y >= aabb.Min.y && point.y <= aabb.Max.y;
        }
    }
}