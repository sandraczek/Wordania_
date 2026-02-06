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
        private readonly IPlayerProvider _playerSpawner;
        public GameplayEntryPoint(IWorldService worldService, IPlayerProvider playerProvider)
        {
            _worldService = worldService;
            _playerSpawner = playerProvider;
        }
        public async UniTask StartAsync(System.Threading.CancellationToken cancellation)
        {
            Debug.Log("<color=green>[GAMEPLAY] Start Sequence Initiated...</color>");

            // KROK 1: Generowanie Świata
            Debug.Log("[1/3] Generating World...");
            
            // Zakładam, że masz metodę Generate() w serwisie. 
            // Jeśli jest async - super. Jeśli nie, po prostu wywołaj ją.
            await _worldService.GenerateWorldAsync(); 

            // KROK 2: Fizyka
            // To jest ten "Senior Trick". Czekamy, aż Unity przetrawi nowe kafelki
            // i stworzy dla nich collidery, zanim postawimy na nich gracza.
            await UniTask.WaitForFixedUpdate();

            // KROK 3: Gracz
            Debug.Log("[2/3] Spawning Player...");
            // Pobieramy bezpieczną pozycję ze świata
            Vector3 spawnPos = _worldService.GetSpawnPoint(); 
            _playerSpawner.SpawnPlayer(spawnPos);

            Debug.Log("<color=green>[3/3] Gameplay Ready!</color>");
        }
    }
}
