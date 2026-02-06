using VContainer;
using VContainer.Unity;
using Wordania.Core.Services;
using Wordania.Boot.Services;

namespace Wordania.Boot
{
    public class ProjectLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SceneLoaderService>(Lifetime.Singleton).As<ISceneLoaderService>();

            builder.RegisterEntryPoint<GameBootstrapper>();
        }
    }
}
