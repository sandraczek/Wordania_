using UnityEngine;
using System;
using System.Collections;
using VContainer;
using Wordania.Gameplay.Services;

namespace Wordania.Gameplay.Player
{
    [SelectionBase]
    [DisallowMultipleComponent]
    public sealed class PlayerHealthView : MonoBehaviour, IDamageable
    {
        private IPlayerHealth _health;
        
        public event Action OnHurt;
        public event Action OnDeath;

        [Inject]
        public void Construct(IPlayerHealth health, IHealthService healthService)
        {
            _health = health;
            
            healthService.OnHealthChanged += HandleHealthChanged;
        }

        public void TakeDamage(float amount)
        {
            _health.TakeDamage(amount);
            OnHurt?.Invoke();
        }

        private void HandleHealthChanged()
        {
            if (_health.Current <= 0) OnDeath?.Invoke();
        }
    }
}