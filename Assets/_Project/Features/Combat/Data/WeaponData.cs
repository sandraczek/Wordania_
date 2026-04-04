using UnityEngine;
using Wordania.Core.Data;
using Wordania.Core.Identifiers;
using Wordania.Features.Combat.Core;

namespace Wordania.Features.Combat.Data
{
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "Combat/Weapon")]
    public sealed class WeaponData : DataAsset
    {
        [Space]
        public string Name;
        [Min(0.001f)]public float FireRate;
        public WeaponType Type;
        public WeaponController Prefab;
        public ProjectileData Projectile;
    }

    public enum WeaponType
    {
        Single,
        Barrel,
        Shotgun,
        Laser
    }
}