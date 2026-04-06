using System;
using UnityEngine;
using VContainer;
using Wordania.Core.Combat;
using Wordania.Core.Services;
using Wordania.Features.Combat;

namespace Wordania.Features.Player
{
    [RequireComponent(typeof(HealthComponent))]
    public class PlayerDebugHandler : MonoBehaviour
    {
        private IDebugService _debugService;
        private InvincibilityController _invincibilityController;

        [Inject]
        public void Construct(IDebugService debugService)
        {
            _debugService = debugService;
        }
        public void Initialize(InvincibilityController invincibility)
        {
            _invincibilityController = invincibility;

            if (_debugService == null) return;

            _debugService.OnGodModeChanged -= HandleGodModeChanged;
            _debugService.OnGodModeChanged += HandleGodModeChanged;
            
            HandleGodModeChanged(_debugService.IsGodModeActive);
        }

        private void OnEnable()
        {
            if (_debugService == null) return;

            _debugService.OnGodModeChanged += HandleGodModeChanged;
            
            HandleGodModeChanged(_debugService.IsGodModeActive);
        }

        private void OnDisable()
        {
            if (_debugService != null)
            {
                _debugService.OnGodModeChanged -= HandleGodModeChanged;
            }
        }

        private void HandleGodModeChanged(bool isGodMode)
        {
            if(_invincibilityController == null) return;

            _invincibilityController.SetInvincibilityRaw(isGodMode); // TODO: fix conflict with dash invincibility
        }
    }
}