using System.Collections.Generic;
using UnityEngine;
using Wordania.Core;
using Wordania.Features.Combat.Data;

namespace Wordania.Features.Combat.FireStrategies
{
    public sealed class StraightFireStrategy : IWeaponFireStrategy
    {
        public int CalculateFireData(Vector2 position, Vector2 direction, WeaponData weaponData, float damageMultiplier, int instigatorId, List<ProjectileSpawnData> resultsBuffer)
        {
            resultsBuffer.Add(new ProjectileSpawnData
            {
                Position = position,
                Direction = direction,
                Data = weaponData.Projectile,
                DamageMultiplier = damageMultiplier,
                InstigatorId = instigatorId
            });

            return 1;
        }
    }
}