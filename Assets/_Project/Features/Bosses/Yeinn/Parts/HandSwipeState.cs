using UnityEngine;
using Wordania.Core.Gameplay;
using Wordania.Core.SFM;
using Wordania.Features.Bosses.Yeinn.Parts;

namespace Wordania.Features.Bosses.Yeinn.Parts
{
    public sealed class YeinnHandSwipeState : IState
    {
        private readonly YeinnHandController _hand;
        private readonly IPlayerProvider _player;
        public YeinnHandSwipeState(YeinnHandController hand, IPlayerProvider player)
        {
            _hand = hand;
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