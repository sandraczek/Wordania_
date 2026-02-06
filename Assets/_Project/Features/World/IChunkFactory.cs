using UnityEngine;

namespace Wordania.Gameplay.World
{
    public interface IChunkFactory
    {
        Chunk Create(Vector2Int coord, Transform parent);
    }
}