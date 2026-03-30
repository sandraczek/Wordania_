using UnityEngine;
using System.Collections.Generic;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Wordania.Features.Combat.Data
{
    [CreateAssetMenu(fileName = "ProjectileDatabase", menuName = "Combat/Projectile Database")]
    public sealed class ProjectileDatabase : ScriptableObject, IProjectileDatabase
    {
        [SerializeField]
        private List<ProjectileData> _allProjectiles = new();
        private Dictionary<int, ProjectileData> _projectileMap;

        public void Initialize() // TO BE REPLACED WITH BELOW
        {
            _projectileMap = new Dictionary<int, ProjectileData>(_allProjectiles.Count);
            foreach (var projectile in _allProjectiles)
            {
                if (projectile == null) continue;
                if(!_projectileMap.TryAdd(projectile.Id.Hash, projectile))
                {
                    Debug.LogWarning($"[ProjectileDatabase] Duplicated ID: {projectile.Id.Hash} for projectile {projectile.name}.");
                }
            }
        }

        public ProjectileData GetProjectile(int id)
        {
            if(id==0) return null;
            if (_projectileMap.TryGetValue(id, out var projectile)) return projectile;
            else Debug.LogError("No id " + id + " in projectile database");
            return null;
        }

        #if UNITY_EDITOR
        [ContextMenu("Auto-Find All Projectiles")]
        public void FindAllProjectilesInProject()
        {
            _allProjectiles ??= new();
            _allProjectiles.Clear();

            string[] guids = AssetDatabase.FindAssets("t:ProjectileData");

            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                ProjectileData projectile = AssetDatabase.LoadAssetAtPath<ProjectileData>(path);
                
                if (projectile != null)
                {
                    _allProjectiles.Add(projectile);
                }
            }
            
            Debug.Log($"Success! Found and added {_allProjectiles.Count} projectiles to database.");
            
            EditorUtility.SetDirty(this); 
        }
        #endif
    }
}