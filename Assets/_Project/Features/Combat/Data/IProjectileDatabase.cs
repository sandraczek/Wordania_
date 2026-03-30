using Wordania.Features.Combat.Data;

namespace Wordania.Features.Combat.Data
{
    public interface IProjectileDatabase
    {
        ProjectileData GetProjectile(int id);
    }
}