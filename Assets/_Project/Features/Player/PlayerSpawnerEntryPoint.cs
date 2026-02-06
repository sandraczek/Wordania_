using UnityEngine;
using VContainer;
using VContainer.Unity;
using Wordania.Core.Gameplay;

namespace Wordania.Gameplay.Player
{
    public sealed class PlayerSpawnerEntryPoint : IStartable, IPlayerProvider
    {
        private readonly GameObject _playerPrefab;
        private readonly Vector2 _spawnPosition = new Vector2(0, 5);
        
        public Transform PlayerTransform { get; private set; }
        public bool IsPlayerSpawned => PlayerTransform != null; 

        public PlayerSpawnerEntryPoint(GameObject playerPrefab)
        {
            _playerPrefab = playerPrefab;
        }

        void IStartable.Start()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            var playerInstance = Object.Instantiate(_playerPrefab, _spawnPosition, Quaternion.identity);
            playerInstance.name = "Player_Entity";
            PlayerTransform = playerInstance.transform;
            
            Debug.Log($"<color=#4AF626>[GAMEPLAY]:</color> Player spawned at {_spawnPosition}");
        }
    }
}