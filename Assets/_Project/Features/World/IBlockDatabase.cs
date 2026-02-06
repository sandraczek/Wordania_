using UnityEngine;
using UnityEngine.Tilemaps;

namespace Wordania.Gameplay.World
{
    public interface IBlockDatabase
    {
        public BlockData GetBlock(int id);
        public TileBase GetCracks(float damage);
    }
}