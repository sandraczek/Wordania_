using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Wordania.Gameplay.World;
using Wordania.Gameplay.Player;
using Wordania.Core.Gameplay;

namespace Wordania.Gameplay
{
    public class GameplayEntryPoint : IAsyncStartable
    {
        private readonly IWorldService _worldService;
        private readonly IPlayerSpawner _playerSpawner;
        public GameplayEntryPoint(IWorldService worldService, IPlayerSpawner playerSpawner)
        {
            _worldService = worldService;
            _playerSpawner = playerSpawner;
        }
        public async UniTask StartAsync(System.Threading.CancellationToken cancellation)
        {
            Debug.Log("<color=green>[GAMEPLAY] Start Sequence Initiated...</color>");
            Debug.Log("[1/3] Generating World...");
            
            await _worldService.GenerateWorldAsync(); 

            await UniTask.WaitForFixedUpdate();
            Time.timeScale = 0f;
            Debug.Log("[2/3] Spawning Player...");

            Vector3 spawnPos = _worldService.GetSpawnPoint(); 
            _playerSpawner.SpawnPlayer(spawnPos);

            Debug.Log("<color=green>[3/3] Gameplay Ready!</color>");
        }
    }
}
