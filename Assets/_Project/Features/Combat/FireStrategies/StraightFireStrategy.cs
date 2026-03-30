using System.Collections.Generic;
using UnityEngine;
using Wordania.Core;
using Wordania.Features.Combat.Data;

namespace Wordania.Features.Combat.FireStrategies
{
    public sealed class StraightFireStrategy : IWeaponFireStrategy
    {
        public int CalculateFireData(WeaponFireContext context, List<ProjectileSpawnData> resultsBuffer)
        {
            resultsBuffer.Add(new ProjectileSpawnData
            {
                Position = context.position,
                Direction = context.direction,
                Data = context.weaponData.Projectile,
                DamageMultiplier = context.damageMultiplier,
                InstigatorId = context.instigatorId,
                TargetFactionMask = context.TargetFactionMask
            });

            return 1;
        }
    }
}