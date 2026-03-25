using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;
using Wordania.Core.Gameplay;
using Wordania.Features.Enemies.Config;

namespace Wordania.Features.Enemies.Core
{
    public sealed class EnemyCullingSystem : ITickable
    {
        private readonly EnemySystemSettings _settings;
        private readonly IPlayerProvider _player;
        private readonly IEnemyRegistryService _registry;

        private readonly List<IEnemy> _enemiesToRemove = new(32);
        private float _timeSinceLastCheck;

        public EnemyCullingSystem(EnemySystemSettings settings, IPlayerProvider playerProvider, IEnemyRegistryService registry)
        {
            _settings = settings;
            _player = playerProvider;
            _registry = registry;
        }
        public void Tick()
        {
            _timeSinceLastCheck += Time.deltaTime;
            if (_timeSinceLastCheck < _settings.CullingInterval) return;
            
            _timeSinceLastCheck -= _settings.CullingInterval;
            PerformDespawnCheck();
        }

        private void PerformDespawnCheck()
        {
            if (_player.PlayerTransform == null) return;

            _enemiesToRemove.Clear();

            Vector2 playerPos = _player.PlayerTransform.position;
            var activeEnemies = _registry.GetActiveEnemies();
            float despawnRadiusSqr = _settings.DespawnRadius * _settings.DespawnRadius;

            foreach (var enemy in activeEnemies)
            {   
                float distanceSqr = (enemy.Position - playerPos).sqrMagnitude;

                if (distanceSqr > despawnRadiusSqr)
                {
                    _enemiesToRemove.Add(enemy);
                }
            }

            // splitting so that safe removal is possible

            foreach (var enemy in _enemiesToRemove)
            {
                enemy.Remove();
            }
        }
    }
}