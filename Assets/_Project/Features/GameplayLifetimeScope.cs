using UnityEngine;
using System;
using VContainer;
using VContainer.Unity;
using Wordania.Gameplay.Player;
using Wordania.Core.Gameplay;
using Wordania.Gameplay.World;
using Wordania.Gameplay.Markers;
using Wordania.Gameplay.Events;

namespace Wordania.Gameplay
{
    public sealed class GameplayLifetimeScope : LifetimeScope
    {
        
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Chunk _chunkPrefab;
        [SerializeField] private WorldSettings _worldSettings;
        [SerializeField] private BlockDatabase _blockDatabase;
        [SerializeField] private WorldChunksRoot _chunksParent;
        [SerializeField] private LootEvent _lootEvent;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_worldSettings);
            _blockDatabase.Initialize();
            builder.RegisterInstance<IBlockDatabase>(_blockDatabase);

            builder.Register<WorldPassTerrain>(Lifetime.Scoped).As<IWorldGenerationPass>();
            builder.Register<WorldPassCave>(Lifetime.Scoped).As<IWorldGenerationPass>();
            builder.Register<WorldPassVariations>(Lifetime.Scoped).As<IWorldGenerationPass>();
            builder.Register<WorldPassBarrier>(Lifetime.Scoped).As<IWorldGenerationPass>();

            builder.Register<WorldGenerator>(Lifetime.Scoped).As<IWorldGenerator>();
            builder.RegisterComponentInHierarchy<Grid>();

            builder.RegisterInstance<LootEvent>(_lootEvent);
            builder.Register<WorldService>(Lifetime.Scoped).As<IWorldService>();

            builder.RegisterComponent(_chunksParent);
            
            builder.Register<ChunkFactory>(Lifetime.Scoped)
                .As<IChunkFactory>()
                .WithParameter(_chunkPrefab);

            builder.RegisterEntryPoint<WorldRenderer>(Lifetime.Scoped);

            builder.Register<PlayerSpawner>(Lifetime.Scoped)
            .As<IPlayerProvider>()
            .WithParameter(_playerPrefab);;     



            builder.RegisterEntryPoint<GameplayEntryPoint>(Lifetime.Scoped);
        }
    }
}