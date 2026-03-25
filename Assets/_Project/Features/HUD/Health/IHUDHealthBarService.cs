using Wordania.Core.Combat;

namespace Wordania.Features.HUD.Health
{
    public interface IHUDHealthBarService
    {
        void UpdateBar(HealthChangeData data);
        void UpdateBarInstant(float current, float max);
    }
}