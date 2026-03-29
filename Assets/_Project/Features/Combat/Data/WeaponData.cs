using UnityEngine;

namespace Wordania.Features.Combat.Data
{
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "Combat/Weapon")]
    public sealed class WeaponData : ScriptableObject
    {
        public float FireRate;
        public WeaponType Type;
        public ProjectileData Projectile;
    }

    public enum WeaponType
    {
        Default,
        Burst,
        Shotgun,
        Laser
    }
}