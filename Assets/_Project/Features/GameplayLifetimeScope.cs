using UnityEngine;
using System;
using VContainer;
using VContainer.Unity;
using Wordania.Gameplay.Player;
using Wordania.Core.Gameplay;
using Wordania.Gameplay.World;
using Wordania.Gameplay.Markers;

namespace Wordania.Gameplay
{
    public sealed class GameplayLifetimeScope : LifetimeScope
    {
        
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _chunkPrefab;
        [SerializeField] private WorldSettings _worldSettings;
        [SerializeField] private BlockDatabase _blockDatabase;
        [SerializeField] private WorldChunksRoot _chunksParent;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_worldSettings);
            _blockDatabase.Initialize();
            builder.RegisterInstance<IBlockDatabase>(_blockDatabase);

            builder.Register<WorldPassTerrain>(Lifetime.Scoped).As<IWorldGenerationPass>();
            builder.Register<WorldPassCave>(Lifetime.Scoped).As<IWorldGenerationPass>();
            builder.Register<WorldPassVariations>(Lifetime.Scoped).As<IWorldGenerationPass>();
            builder.Register<WorldPassBarrier>(Lifetime.Scoped).As<IWorldGenerationPass>();

            builder.Register<WorldGenerator>(Lifetime.Scoped);
            builder.RegisterComponentInHierarchy<Grid>();

            builder.Register<WorldService>(Lifetime.Scoped).As<IWorldService>();

            builder.RegisterComponent(_chunksParent);
            
            builder.Register<ChunkFactory>(Lifetime.Scoped)
                .As<IChunkFactory>()
                .WithParameter(_chunkPrefab);

            builder.RegisterEntryPoint<WorldRenderer>();

            builder.RegisterEntryPoint<PlayerSpawnerEntryPoint>(Lifetime.Singleton)
                .AsSelf()
                .As<IPlayerProvider>()
                .WithParameter(_playerPrefab);
        }
    }
}