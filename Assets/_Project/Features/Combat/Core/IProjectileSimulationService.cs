using System;
using Wordania.Core.Combat;
using Wordania.Features.Combat.Data;

namespace Wordania.Features.Combat.Core
{

    public interface IProjectileSimulationService
    {
        event Action<ProjectileView> OnProjectileDeath;
        void Register(ref ProjectileRuntimeData runtimeData, ProjectileView view);
    }
}