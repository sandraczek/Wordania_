using UnityEngine;
using Wordania.Core.SFM;
using Wordania.Core.Gameplay;
using Wordania.Core.Combat;
using VContainer;
using Wordania.Features.Bosses.Data;

namespace Wordania.Features.Bosses.Yeinn.Parts
{
    [RequireComponent(typeof(HealthComponent))]
    public sealed class YeinnHeadController : MonoBehaviour, IDamageable
    {
        private BossPartData _data;
        private StateMachine<IState> _stateMachine;
        private HealthComponent _health;
        private IPlayerProvider _playerProvider;
        private readonly DamageMitigator _mitigation = new();

        // Local States
        private IState _hoverState;
        private IState _chaseState;
        private IState _slamState;

        public bool IsDefeated { get; private set; }

        [Inject]
        public void Construct(IPlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
        }
        public void Initialize(BossPartData headData)
        {
            _data = headData;

            _stateMachine.SwitchState(_hoverState);
            _stateMachine = new StateMachine<IState>();

            _hoverState = new YeinnHeadHoverState(this, _playerProvider);
            _chaseState = new YeinnHeadChaseState(this, _playerProvider);
            _chaseState = new YeinnHeadSlamState(this, _playerProvider);


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

        public void CommandSlamAttack() => ChangeStateIfNotDefeated(_slamState);
        public void CommandChase() => ChangeStateIfNotDefeated(_chaseState);
        public void CommandHover() => ChangeStateIfNotDefeated(_hoverState);

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

            Debug.Log("Yeinn head defeated");
            IsDefeated = true;
        }
        public void SetGeneralResistance(float res)
        {
            _mitigation.SetGeneralResistance(res);
        }
    }
}