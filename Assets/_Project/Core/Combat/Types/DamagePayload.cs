using UnityEngine;

namespace Wordania.Core.Combat
{
    public readonly struct DamagePayload
    {
        public const int EnvironmentId = -1;
        public readonly float Amount;
        public readonly DamageType Type;
        public readonly HealthChangeSource Source;
        public readonly int InstigatorId; 
        public readonly Vector2 HitPoint;      
        public readonly Vector2 Knockback;  

        public DamagePayload(
            float amount, 
            DamageType type, 
            HealthChangeSource source,
            int instigatorId, 
            Vector2 hitPoint, 
            Vector2 knockback)
        {
            Amount = Mathf.Max(0f, amount); 
            
            Type = type;
            Source = source;
            InstigatorId = instigatorId;
            HitPoint = hitPoint;
            Knockback = knockback;
        }
    }
}