using UnityEngine;
using VContainer;
using Wordania.Core.HUD;
using Wordania.Core.Inputs;

namespace Wordania.Features.HUD.Skills
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class SkillTreeDisplay : MonoBehaviour
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
            _inputs.OnToggleSkillTree += HandleSkillTreeToggle;
            _isOpen = false;
            SetTreeState(false);
        }
        private void OnDestroy()
        {
            if (_inputs != null)
            {
                _inputs.OnToggleMap -= HandleSkillTreeToggle;
            }
        }

        private void HandleSkillTreeToggle()
        {
            _isOpen = !_isOpen;
            SetTreeState(_isOpen);
        }

        private void SetTreeState(bool open)
        {
            if (open) _hud.RegisterOpenWindow(this);
            else _hud.UnregisterOpenWindow(this);

            _canvasGroup.alpha = open ? 1f : 0f;
            _canvasGroup.interactable = open;
            _canvasGroup.blocksRaycasts = open;
        }
    }
}