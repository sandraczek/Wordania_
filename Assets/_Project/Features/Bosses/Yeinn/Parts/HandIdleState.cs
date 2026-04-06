using UnityEngine;
using Wordania.Core.Gameplay;
using Wordania.Core.SFM;
using Wordania.Features.Bosses.Yeinn.Parts;

namespace Wordania.Features.Bosses.Yeinn.Parts
{
    public sealed class YeinnHandIdleState : IState
    {
        private readonly YeinnHandController _hand;
        private readonly IPlayerProvider _player;
        private readonly Transform _headAnchor;
        public YeinnHandIdleState(YeinnHandController hand, IPlayerProvider player, Transform headAnchor)
        {
            _hand = hand;
            _player = player;
            _headAnchor = headAnchor;
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