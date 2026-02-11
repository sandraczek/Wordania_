using System;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Wordania.Core;
using Wordania.Gameplay.Inventory;
using Wordania.Gameplay.Player.States;

namespace Wordania.Gameplay.Player
{
    [RequireComponent(typeof(PlayerStateMachine))]
    [RequireComponent(typeof(PlayerController))]
    [RequireComponent(typeof(PlayerHealthView))]
    public class Player : MonoBehaviour//, ISaveable
    {
        [Header("Components")]
        private PlayerController _controller;
        public PlayerController Controller =>_controller; // temporary for GameplayState to connect camera
        private PlayerStateMachine _states;
        private PlayerHealthView _health;
        [SerializeField] private PlayerVisuals visuals;

        [Header("Dependencies")]
        private IInputReader _inputs;
        private PlayerStateFactory _factory;
        private PlayerConfig _config;
        //private ISaveService _save;
        
        [Header("Save Data")]
        public string PersistenceId => "Player";  
        [Inject]
        public void Construct(IInputReader inputs, PlayerConfig config, IInventoryService inventory)//, ISaveService save)
        {
            _controller = GetComponent<PlayerController>();
            _states = GetComponent<PlayerStateMachine>();
            _health = GetComponent<PlayerHealthView>();

            
            _inputs = inputs;
            _config = config;
            //_save = save;
            Debug.Log("Injecting to player");
            //_save.Register(this);

            PlayerContext context = new(_states, _controller, _health, config, transform);
            _factory = new(context, inputs, inventory);
        }
        public void Initialize()
        {
            _states.Initialize(_factory.InitialState);
        }
        public void OnDestroy()
        {
            //_save.Unregister(this);
        }
        private void OnEnable()
        {
            _health.OnHurt += HandleHurt;     // to do - make player not a god object
            _health.OnHurt += HandleHurtVisuals;
            _health.OnDeath += HandleDeath;
            _controller.OnLanded += HandleLanding;
            _inputs.OnToggleInventory += HandleInventoryToggle;
        }

        private void OnDisable()
        {
            _health.OnHurt -= HandleHurt;
            _health.OnHurt -= HandleHurtVisuals;
            _health.OnDeath -= HandleDeath;
            _controller.OnLanded -= HandleLanding;
            _inputs.OnToggleInventory -= HandleInventoryToggle;
        }
        private void HandleHurt()
        {
            _states.SwitchState(_factory.Hurt);
        }

        private void HandleDeath()
        {
            //_states.SwitchState(_states.Factory.Dead);
        }
        private void HandleInventoryToggle()
        {
            if (_states.CurrentState == _factory.InMenu)
            {
                _states.SwitchState(_factory.Idle);
            }
            else
            {
                _states.SwitchState(_factory.InMenu);
            }
        }
        private void HandleLanding(float velocity)  // to move
        {
            if (velocity > _config.fallDamageThreshold)
            {
                float damage = CalculateFallDamage(velocity);
                if(damage > 0f) _health.TakeDamage(damage);
            }
        }
        private float CalculateFallDamage(float velocity) // to move
        {
            return (velocity - _config.fallDamageThreshold) * _config.fallDamageMultiplier;
        }
        private void HandleHurtVisuals()
        {
            visuals.PlayHurtEffect();
        }

        // ----- Save -----

        // public object CaptureState()
        // {
        //     return new PlayerSaveData(
        //         _controller.Position
        //     );
        // }

        // public void RestoreState(object state)
        // {
        //     if (state is Newtonsoft.Json.Linq.JObject jObject)
        //     {
        //         var dataJ = jObject.ToObject<PlayerSaveData>();
        //         ApplyData(dataJ);
        //     }
        //     else if (state is PlayerSaveData data)
        //     {
        //         ApplyData(data);
        //     }
        // }
        // private void ApplyData(PlayerSaveData data)
        // {
        //     if (data == null) return;
        //     _controller.Position = data.Position;
        // }
    }
}