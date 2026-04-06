using UnityEngine;
using Wordania.Core.SFM;
using Wordania.Core.Gameplay;
using Wordania.Core.Combat;
using VContainer;
using Wordania.Features.Bosses.Data;

namespace Wordania.Features.Bosses.Yeinn.Parts
{
    [RequireComponent(typeof(HealthComponent))]
    public sealed class YeinnHandController : MonoBehaviour, IDamageable
    {
        private BossPartData _data;
        private StateMachine<IState> _stateMachine;
        private HealthComponent _health;
        private IPlayerProvider _playerProvider;
        private readonly DamageMitigator _mitigation = new();

        // Local States
        private IState _idleState;
        private IState _swipeState;
        private IState _slamState;

        public bool IsDefeated { get; private set; }

        [Inject]
        public void Construct(IPlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
        }
        public void Initialize(BossPartData handData, Transform headAnchor)
        {
            _data = handData;
            
            _stateMachine.SwitchState(_idleState);
            _stateMachine = new StateMachine<IState>();

            _idleState = new YeinnHandIdleState(this, _playerProvider, headAnchor);
            _swipeState = new YeinnHandSwipeState(this, _playerProvider);
            _slamState = new YeinnHandSlamState(this, _playerProvider);

            _mitigation.Initialize
            (
                _data.GeneralResistance,
                _data.PhysicalResistance,
                _data.MagicalResistance,
                _data.EnvironmentalResistance,
                _data.FallResistance
            );
            _health.SetInitial(_data.MaxHealth);
        }
        private void Awake()
        {
            _health = GetComponent<HealthComponent>();
        }
        private void OnEnable()
        {
            _health.OnDeath += HandleDeath;
        }

        private void Update()
        {
            if (IsDefeated) return;
            
            _stateMachine.Update();
        }
        private void FixedUpdate()
        {
            if (IsDefeated) return;

            _stateMachine.FixedUpdate();
        }

        public void CommandSwipeAttack() => ChangeStateIfNotDefeated(_swipeState);
        public void CommandSlamAttack() => ChangeStateIfNotDefeated(_slamState);
        public void CommandIdle() => ChangeStateIfNotDefeated(_idleState);

        private void ChangeStateIfNotDefeated(IState newState)
        {
            if (IsDefeated) return;

            _stateMachine.SwitchState(newState);
        }

        public void ApplyDamage(DamagePayload payload)
        { 
            if(IsDefeated) return;

            DamageResult damageResult = _mitigation.ProcessDamage(payload);
            _health.ApplyDamage(damageResult);
        } 
        private void HandleDeath()
        {
            if(IsDefeated) return;

            Debug.Log("Yeinn hand defeated");
            IsDefeated = true;
        }
    }
}