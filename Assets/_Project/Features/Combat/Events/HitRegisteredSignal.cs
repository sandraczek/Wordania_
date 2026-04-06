using System;
using Unity.Mathematics;
using UnityEngine;
using Wordania.Core.Events;

namespace Wordania.Features.Combat.Events
{
    public struct ProjectileHitEvent
    {
        public float2 Direction;
        public int ProjectileDataId;
        public int HitEntityId;
        public float2 HitPosition;
        public float DamageMultiplier; 
        public int InstigatorId;
    }

    [CreateAssetMenu(menuName = "Signals/HitRegistered")]
    public sealed class HitRegisteredSignal : BaseSignal<ProjectileHitEvent>
    {

    }
}