using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using Wordania.Core.Combat;
using Wordania.Core.Gameplay;
using Wordania.Core.Services;

namespace Wordania.Features.Services
{
    public class EntityTrackerService :IEntityTrackerService, IDisposable
    {
        private readonly Dictionary<int, ITrackable> _registry = new();
        private NativeList<TargetAABB> _nativeList = new(1000, Allocator.Persistent);
        private bool _isDirty = true;

        public void Dispose()
        {
            if(_nativeList.IsCreated){
                _nativeList.Dispose();
                _nativeList = default;
            }
        }
        public void Register(ITrackable trackable)
        {
            _registry[trackable.InstanceId] = trackable;
            _isDirty = true;
        }

        public void Unregister(int entityId)
        {
            _registry.Remove(entityId);
            _isDirty = true;
        }
        public NativeArray<TargetAABB> GetTargetsForJob(Allocator allocator)
        {
            if (_isDirty)
            {   
                _nativeList.Clear();
                
                int i = 0;
                foreach (var entity in _registry.Values)
                {
                    Bounds bounds = entity.Hitbox;
                    _nativeList.Add(new TargetAABB
                    {
                        EntityInstanceId = entity.InstanceId,
                        FactionId = (int)entity.Faction,
                        Min = new Unity.Mathematics.float2(bounds.min.x, bounds.min.y),
                        Max = new Unity.Mathematics.float2(bounds.max.x, bounds.max.y)
                    });
                    i++;
                }
                _isDirty = false;
            }

            return _nativeList.AsArray();
        }
    }
}