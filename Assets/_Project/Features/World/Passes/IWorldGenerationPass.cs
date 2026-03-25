using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Wordania.Features.World
{
    public interface IWorldGenerationPass 
    {
        UniTask Execute(CancellationToken token,  WorldData data);
    }
}