using UnityEngine;
using Wordania.Core.Identifiers;

namespace Wordania.Core.Combat
{
    public interface IDamageable : IEntity
    {
        void ApplyDamage(DamagePayload payload);
    }
}