using UnityEngine;
using Wordania.Core;
using Wordania.Core.Inputs;
using Wordania.Features.Inventory;

namespace Wordania.Features.Player.FSM
{
    public sealed class PlayerInMenuState : PlayerBaseState
    {
        private readonly IInventoryService _inventoryService;
        public PlayerInMenuState(PlayerContext context, IInputReader inputs, PlayerStateFactory playerStateFactory, IInventoryService inventoryService) : base(context, inputs, playerStateFactory)
        {
            _inventoryService = inventoryService;
        }

        public override void CheckSwitchStates()
        {

        }

        public override void Enter()
        {
            
        }

        public override void Exit()
        {
            
        }

        public override void FixedUpdate()
        {

        }

        public override void Update()
        {

        }
    }
}