using UnityEngine;

namespace Wordania.Features.Combat.Data
{
    public struct ProjectileSpawnData
    {
        public Vector3 Position;
        public Vector2 Direction;
        public ProjectileData Data;
        public float DamageMultiplier;
        public int InstigatorId;
    }
}