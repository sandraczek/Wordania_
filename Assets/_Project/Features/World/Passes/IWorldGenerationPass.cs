using UnityEngine;

namespace Wordania.Gameplay.World
{
    public interface IWorldGenerationPass 
    {
        void Execute(WorldData data);
    }
}