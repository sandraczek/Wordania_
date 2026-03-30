using Wordania.Features.Combat.Data;
using UnityEngine;
using System.Collections.Generic;

namespace Wordania.Features.Combat.FireStrategies
{
    public interface IWeaponFireStrategy
    {
        public int CalculateFireData(WeaponFireContext context, List<ProjectileSpawnData> resultsBuffer);
    }
}