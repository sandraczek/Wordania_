using VContainer;
using VContainer.Unity;
using Wordania.Core.Services;
using Wordania.Boot.Services;
using Wordania.Core;
using System;
using UnityEngine;

namespace Wordania.Boot
{
    public class ProjectLifetimeScope : LifetimeScope
    {
        [SerializeField] private InputReader _inputReader;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SceneLoaderService>(Lifetime.Singleton).As<ISceneLoaderService>();
            builder.Register<DebugService>(Lifetime.Singleton).As<IDebugService>();
            builder.RegisterInstance<IInputReader>(_inputReader);

            builder.RegisterEntryPoint<GameBootstrapper>();
        }
    }
}
