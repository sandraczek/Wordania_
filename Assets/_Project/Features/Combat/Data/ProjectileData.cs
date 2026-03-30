using System;
using UnityEngine;
using Wordania.Core.Combat;
using Wordania.Core.Identifiers;

namespace Wordania.Features.Combat.Data
{
    [CreateAssetMenu(fileName = "NewProjectile", menuName = "Combat/Projectile")]
    public sealed class ProjectileData : ScriptableObject
    {
        [field: SerializeField] public AssetId Id { get; private set; }
        
        public string DisplayName { get; private set; } = "Projectile";

        public float BaseDamage = 0f;
        public Vector2 Knockback = new(15f,7f);
        public float Speed = 30f;
        public float Lifetime = 1f;
        public int Piercing = 0;
        public float GravityScale = 0f;
        public DamageType damageType = DamageType.Physical;
        public ProjectileView Prefab;

        private void OnValidate()
        {
            var currentId = Id;
            currentId.EditorInitialize();
            Id = currentId;
        }
    }
}