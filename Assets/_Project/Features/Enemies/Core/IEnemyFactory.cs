using Cysharp.Threading.Tasks;
using UnityEngine;
using Wordania.Core.Gameplay;
using Wordania.Features.Enemies.Data;

namespace Wordania.Features.Enemies.Core
{
    public interface IEnemyFactory
    {
        IEnemy CreateEnemy(EnemyTemplate data, Vector3 position);
        public UniTask PrewarmPoolAsync(EnemyTemplate template);
    }
}