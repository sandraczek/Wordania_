using UnityEngine;
using VContainer;
using VContainer.Unity;
using Wordania.Core.Gameplay;

namespace Wordania.Gameplay.Player
{
    public sealed class PlayerSpawner : IPlayerProvider
    {
        private readonly GameObject _playerPrefab;
        
        public Transform PlayerTransform { get; private set; }
        public bool IsPlayerSpawned => PlayerTransform != null; 

        public PlayerSpawner(GameObject playerPrefab)
        {
            _playerPrefab = playerPrefab;
        }

        public void SpawnPlayer(Vector2 spawnPosition)
        {
            var playerInstance = Object.Instantiate(_playerPrefab, spawnPosition, Quaternion.identity);
            playerInstance.name = "Player";
            PlayerTransform = playerInstance.transform;
            
            Debug.Log($"<color=#4AF626>[GAMEPLAY]:</color> Player spawned at {spawnPosition}");
        }
    }
}