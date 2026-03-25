using UnityEngine;

namespace Wordania.Features.World
{
    public interface IChunkFactory
    {
        Chunk Create(Vector2Int coord, Transform parent);
    }
}