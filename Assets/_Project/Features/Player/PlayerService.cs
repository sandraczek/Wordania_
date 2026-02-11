using UnityEngine;
using VContainer;
using VContainer.Unity;
using Wordania.Core.Gameplay;

namespace Wordania.Gameplay.Player
{
    public sealed class PlayerService : IPlayerProvider, IPlayerSpawner
    {
        private readonly GameObject _playerPrefab;
        private readonly IObjectResolver _resolver;
        
        public Transform PlayerTransform { get; private set; }
        public bool IsPlayerSpawned => PlayerTransform != null; 

        public PlayerService(GameObject playerPrefab, IObjectResolver resolver)
        {
            _playerPrefab = playerPrefab;
            _resolver = resolver;
        }

        public void SpawnPlayer(Vector2 spawnPosition)
        {
            var playerInstance = _resolver.Instantiate(_playerPrefab, spawnPosition, Quaternion.identity);
            playerInstance.name = "Player";
            PlayerTransform = playerInstance.transform;


            if(playerInstance.TryGetComponent<Player>(out Player player))
            {
                player.Initialize();
            }
            
            
            Debug.Log($"<color=#4AF626>[GAMEPLAY]:</color> Player spawned at {spawnPosition}");
        }
    }
}