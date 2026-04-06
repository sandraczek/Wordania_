using UnityEngine;
using Wordania.Core.Gameplay;
using Wordania.Core.SFM;
using Wordania.Features.Bosses.Yeinn.Parts;

namespace Wordania.Features.Bosses.Yeinn.Parts
{
    public sealed class YeinnHeadChaseState : IState
    {
        private readonly YeinnHeadController _head;
        private readonly IPlayerProvider _player;
        public YeinnHeadChaseState(YeinnHeadController head, IPlayerProvider player)
        {
            _head = head;
            _player = player;
        }

        public void CheckSwitchStates()
        {

        }
        public void Enter()
        {

        }

        public void Update()
        {

        }
        public void FixedUpdate()
        {
            
        }
        public void Exit()
        {

        }
    }
}