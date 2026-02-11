using UnityEngine;
using System;
using VContainer;
using VContainer.Unity;
using Wordania.Gameplay.Player;
using Wordania.Core.Gameplay;
using Wordania.Gameplay.World;
using Wordania.Gameplay.Markers;
using Wordania.Gameplay.Events;
using Wordania.Gameplay.Inventory;
using Wordania.Gameplay.Player.States;
using Wordania.Gameplay.Services;
using Wordania.Core;

namespace Wordania.Gameplay
{
    public sealed class GameplayLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Chunk _chunkPrefab;
        [SerializeField] private WorldSettings _worldSettings;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private BlockDatabase _blockDatabase;
        [SerializeField] private ItemDatabase _itemDatabase;
        [SerializeField] private WorldChunksRoot _chunksParent;
        [SerializeField] private LootEvent _lootEvent;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_worldSettings);
            _blockDatabase.Initialize();
            builder.RegisterInstance<IBlockDatabase>(_blockDatabase);
            _itemDatabase.Initialize();
            builder.RegisterInstance<IItemDatabase>(_itemDatabase);

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

            builder.RegisterInstance(_playerConfig);
            builder.Register<PlayerInventoryService>(Lifetime.Scoped).As<IInventoryService>();
            builder.Register<PlayerHealthProcessor>(Lifetime.Scoped).As<IPlayerHealth>();
            builder.Register<PlayerHealthService>(Lifetime.Scoped).As<IHealthService>();
            builder.Register<PlayerService>(Lifetime.Scoped)
            .AsSelf()
            .As<IPlayerProvider>()
            .As<IPlayerSpawner>()
            .WithParameter(_playerPrefab);



            builder.RegisterEntryPoint<GameplayEntryPoint>(Lifetime.Scoped);
        }
    }
}