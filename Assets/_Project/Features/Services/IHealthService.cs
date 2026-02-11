using System;
using UnityEngine;

namespace Wordania.Gameplay.Services
{
    public interface IHealthService // ----- to change (enemies cant have own services - to heavy) ----
    {
        float Current { get; }
        float Max { get; }
        public void ModifyHealth(float amount);
        public void SetHealth(float health);
        public void Initialize(float current, float max);
        event Action OnHealthChanged;
    }
}