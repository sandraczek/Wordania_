using System.Collections.Generic;
using Unity.Collections;
using Wordania.Core.Combat;
using Wordania.Features.Combat.Core;

namespace Wordania.Features.Services
{
    public class EntityRegistryService : IEntityRegistryService
    {
        private readonly Dictionary<int, IDamageable> _registry = new();

        public void Register(int entityId, IDamageable damageable)
        {
            _registry[entityId] = damageable;
        }

        public void Unregister(int entityId)
        {
            _registry.Remove(entityId);
        }

        public IDamageable GetDamageable(int entityId)
        {
            _registry.TryGetValue(entityId, out var damageable);
            return damageable; // Returns null if not found
        }
    }
}