using System;
using System.Xml.Serialization;
using UnityEngine;
using Wordania.Core.Combat;
using Wordania.Core.Data;
using Wordania.Core.Identifiers;

namespace Wordania.Features.Combat.Data
{
    [CreateAssetMenu(fileName = "NewProjectile", menuName = "Combat/Projectile")]
    public sealed class ProjectileData : DataAsset
    {   
        [Space]
        public string Name = "Projectile";
        public float BaseDamage = 0f;
        public Vector2 Knockback = new(5f,6f);
        public float Speed = 30f;
        public float Lifetime = 1f;
        public int Piercing = 0;
        public float GravityScale = 0f;
        public DamageType damageType = DamageType.Physical;
        public ProjectileView Prefab;
    }
}