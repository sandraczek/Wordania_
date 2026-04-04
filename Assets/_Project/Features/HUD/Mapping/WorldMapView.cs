namespace Wordania.Features.Mapping
{
    using UnityEngine;
    using VContainer;
    using Wordania.Core.HUD;
    using Wordania.Core.Inputs;

    [RequireComponent(typeof(CanvasGroup))]
    public class WorldMapView : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;
        
        private IInputReader _inputs;
        private IHUDStateManager _hud;
        private bool _isOpen = false;

        [Inject]
        public void Construct(IInputReader inputs, IHUDStateManager hudManager)
        {
            _inputs = inputs;
            _hud = hudManager;
        }
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        private void Start()
        {
            _inputs.OnToggleMap += HandleMapToggle;
            _isOpen = false;
            SetMapState(false);
        }
        private void OnDestroy()
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
            if (open) _hud.RegisterOpenWindow(this);
            else _hud.UnregisterOpenWindow(this);
            
            _canvasGroup.alpha = open? 1f:0f;
            _canvasGroup.interactable = open;
            _canvasGroup.blocksRaycasts = open;
        }
    }
}