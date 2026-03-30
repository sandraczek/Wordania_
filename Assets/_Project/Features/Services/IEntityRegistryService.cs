using Wordania.Core.Combat;

namespace Wordania.Features.Services
{
    public interface IEntityRegistryService
    {
        void Register(int entityId, IDamageable damageable);
        void Unregister(int entityId);
        IDamageable GetDamageable(int entityId);
    }
    }