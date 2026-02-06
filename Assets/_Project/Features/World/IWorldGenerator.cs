using UnityEngine;

namespace Wordania.Gameplay.World
{
    public interface IWorldGenerator
    {
        public WorldData GenerateWorld();
    }
}