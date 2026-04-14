// LightmapPresenter.cs
using System;
using VContainer.Unity;
using Wordania.Features.World;
using Wordania.Features.World.Data;
using Wordania.World.Lighting;

namespace Wordania.World.Lighting // lub Wordania.World.Presentation
{
    /// <summary>
    /// Binds the core lighting logic to the GPU rendering system.
    /// </summary>
    public class LightmapPresenter : IStartable, IDisposable, ILateTickable
    {
        private readonly IWorldService _world;
        private readonly ILightingService _lightingService;
        private readonly ILightmapRenderer _lightmapRenderer;

        private bool _isDirty = false;

        public LightmapPresenter(
            IWorldService world,
            ILightingService lightingService,
            ILightmapRenderer lightmapRenderer)
        {
            _world = world;
            _lightingService = lightingService;
            _lightmapRenderer = lightmapRenderer;
        }

        public void Start()
        {
            _lightingService.OnLightingUpdated += MarkAsDirty;
            MarkAsDirty();
        }

        private void MarkAsDirty()
        {
            _isDirty = true;
        }

        public void LateTick()
        {
            if (!_isDirty) return;
            if (_world.Data == null) return;

            _isDirty = false;

            _lightmapRenderer.ApplyLightmap(_world.Data.Tiles);
        }

        public void Dispose()
        {
            if (_lightingService != null)
            {
                _lightingService.OnLightingUpdated -= MarkAsDirty;
            }
        }
    }
}