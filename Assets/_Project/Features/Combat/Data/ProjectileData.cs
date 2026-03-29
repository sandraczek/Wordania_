using System;
using UnityEngine;
using Wordania.Core.Combat;
using Wordania.Core.Identifiers;

namespace Wordania.Features.Combat.Data
{
    [CreateAssetMenu(fileName = "NewProjectile", menuName = "Combat/Projectile")]
    public sealed class ProjectileData : ScriptableObject
    {
        public AssetId Id { get; private set; }
        
        public string DisplayName { get; private set; } = "Projectile";

        public float BaseDamage;
        public float Speed;
        public float Lifetime;
        public int Piercing = 0;
        public float GravityScale = 0f;
        public ProjectileView Prefab;

        private void OnValidate()
        {
            var currentId = Id;
            currentId.EditorInitialize();
            Id = currentId;
        }
    }
}