using System.Collections.Generic;
using Wordania.Core.Gameplay;

namespace Wordania.Features.Enemies.Core
{
    public interface IEnemyRegistryService
    {
        void Register(IEnemy enemy);
        void Unregister(IEnemy enemy);
        IReadOnlyCollection<IEnemy> GetActiveEnemies();
    }
}