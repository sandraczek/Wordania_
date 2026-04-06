using Unity.Collections;
using Wordania.Core.Gameplay;

namespace Wordania.Core.Services
{
    public interface IEntityTrackerService : IRegistry<ITrackable>
    {
        NativeArray<TargetAABB> GetTargetAABBs();
    }
}