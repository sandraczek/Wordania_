using Wordania.Features.Combat.Data;
using UnityEngine;
using System.Collections.Generic;

namespace Wordania.Features.Combat.FireStrategies
{
    public interface IWeaponFireStrategy
    {
        public int CalculateFireData(Vector2 position, Vector2 direction, WeaponData data, List<ProjectileSpawnData> resultsBuffer);
    }
}