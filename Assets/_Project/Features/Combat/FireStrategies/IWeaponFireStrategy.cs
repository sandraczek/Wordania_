using Wordania.Features.Combat.Data;
using UnityEngine;
using System.Collections.Generic;

namespace Wordania.Features.Combat.FireStrategies
{
    public interface IWeaponFireStrategy
    {
        WeaponType Type { get; }
        public int CalculateFireData(WeaponFireContext context, WeaponFireData weaponData, List<ProjectileSpawnData> resultsBuffer);
    }
}