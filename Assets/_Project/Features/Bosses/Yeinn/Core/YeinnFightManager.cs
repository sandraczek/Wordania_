using UnityEngine;
using Wordania.Core.Identifiers;
using Wordania.Core.SFM;
using Wordania.Features.Bosses.Core;
using Wordania.Features.Bosses.Data;
using Wordania.Features.Bosses.Events;
using Wordania.Features.Bosses.Yeinn.Data;
using Wordania.Features.Bosses.Yeinn.Parts;

namespace Wordania.Features.Bosses.Yeinn.Core
{
    public sealed class YeinnBossController : BossController<YeinnTemplate>
    {
        [Header("Dependencies")]
        private BossDefeatedSignal _defeatedSignal;
        [Header("Boss Parts")]
        [SerializeField] private YeinnHeadController _head;
        [SerializeField] private YeinnHandController _leftHand;
        [SerializeField] private YeinnHandController _rightHand;

        private StateMachine<IState> _phaseStateMachine;
        
        // Phases
        private IState _phaseOne;
        private IState _phaseTwo;
        private IState _death;

        public bool AreBothHandsDefeated => _leftHand.IsDefeated && _rightHand.IsDefeated;

        public void Construct(BossDefeatedSignal defeatedSignal)
        {
            _defeatedSignal = defeatedSignal;
        }
        protected override void OnInitialize(YeinnTemplate template)
        {
            _template = template;

            _head.Initialize(template.Head);
            _leftHand.Initialize(template.LeftHand, _head.transform);
            _rightHand.Initialize(template.RightHand, _head.transform);

            _phaseStateMachine = new StateMachine<IState>();

            _phaseOne = new YeinnPhaseOneState(template.PhaseOneData, this, _head, _leftHand, _rightHand);
            _phaseTwo = new YeinnPhaseTwoState(template.PhaseTwoData, this, _head);
            _death = new YeinnDeathState(this);

            _phaseStateMachine.SwitchState(_phaseOne);
        }

        private void Update()
        {
            _phaseStateMachine.Update();
        }
        private void FixedUpdate()
        {
            _phaseStateMachine.FixedUpdate();
        }

        public void TransitionToPhaseTwo()
        {
            _phaseStateMachine.SwitchState(_phaseTwo);
        }
        public void TransitionToDeath()
        {
            _phaseStateMachine.SwitchState(_death); 
        }
        public override void OnDeathSequenceComplete()
        {
            _defeatedSignal.Raise();
        }
    }
}