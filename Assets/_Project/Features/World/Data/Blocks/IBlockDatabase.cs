using UnityEngine;
using UnityEngine.Tilemaps;

namespace Wordania.Features.World
{
    public interface IBlockDatabase
    {
        public BlockData GetBlock(int id);
        public TileBase GetCracks(float damage);
    }
}