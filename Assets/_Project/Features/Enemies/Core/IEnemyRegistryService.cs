using System.Collections.Generic;
using Unity.Collections;
using Wordania.Core.Gameplay;
using Wordania.Features.Combat.Core;

namespace Wordania.Features.Enemies.Core
{
    public interface IEnemyRegistryService
    {
        void Register(IEnemy enemy);
        void Unregister(IEnemy enemy);
        IReadOnlyCollection<IEnemy> GetActiveEnemies();
    }
}