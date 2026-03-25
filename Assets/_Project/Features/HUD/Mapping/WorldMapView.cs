namespace Wordania.Features.Mapping
{
    using UnityEngine;
    using VContainer;
    using Wordania.Core.HUD;
    using Wordania.Core.Inputs;

    public class WorldMapView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        
        private IInputReader _inputs;
        private IHUDStateManager _hud;
        private bool _isOpen = false;

        [Inject]
        public void Construct(IInputReader inputs, IHUDStateManager hudManager)
        {
            _inputs = inputs;
            _hud = hudManager;
        }
        private void Start()
        {
            _isOpen = false;
            SetMapState(false);
        }
        private void OnEnable()
        {
            _inputs.OnToggleMap += HandleMapToggle;
        }

        private void OnDisable()
        {
            if (_inputs != null)
            {
                _inputs.OnToggleMap -= HandleMapToggle;
            }
        }

        private void HandleMapToggle()
        {
            _isOpen = !_isOpen;
            SetMapState(_isOpen);
        }

        private void SetMapState(bool open)
        {
            if (open)
            {
                _hud.RegisterOpenWindow(this);
                _canvasGroup.alpha = 1f;
            }
            else
            {
                _hud.UnregisterOpenWindow(this);
                _canvasGroup.alpha = 0f;
            }
        }
    }
}