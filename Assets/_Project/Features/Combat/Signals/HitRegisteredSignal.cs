using System;
using Unity.Mathematics;
using UnityEngine;

namespace Wordania.Features.Combat.Signals
{
    public struct ProjectileHitEvent
    {
        public int ProjectileDataId;
        public int HitEntityId;
        public float2 HitPosition;
        public float DamageMultiplier; 
        public int InstigatorId;
    }

    [CreateAssetMenu(menuName = "Signals/HitRegistered")]
    public sealed class HitRegisteredSignal : ScriptableObject
    {
        private Action<ProjectileHitEvent> _onTriggered;

        public void Raise(ProjectileHitEvent hit) => _onTriggered?.Invoke(hit);

        public void Subscribe(Action<ProjectileHitEvent> listener) => _onTriggered += listener;
        public void Unsubscribe(Action<ProjectileHitEvent> listener) => _onTriggered -= listener;
    }
}