using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Wordania.Features.World
{
    public interface IWorldGenerator
    {
        public UniTask<WorldData> GenerateWorldAsync(CancellationToken token);
    }
}