// ILightingService.cs
using System;
using Wordania.Features.World.Data;

namespace Wordania.World.Lighting
{
    public interface ILightingService
    {
        event Action OnLightingUpdated;
        byte GetLightLevel(int x, int y);

        /// <summary>
        /// Call this when a block is placed or removed. 
        /// It recalculates the light spread around the given coordinates.
        /// </summary>
        void UpdateLightAt(int x, int y);
    }
}