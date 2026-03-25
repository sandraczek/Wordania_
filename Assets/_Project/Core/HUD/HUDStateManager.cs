using System.Collections.Generic;
using Codice.Client.Common;
using VContainer;
using Wordania.Core.Inputs;

namespace Wordania.Core.HUD
{
    public class HUDStateManager : IHUDStateManager
    {
        private readonly IInputReader _inputs;
        private readonly HashSet<object> _activeWindows = new();

        [Inject]
        public HUDStateManager(IInputReader inputs)
        {
            _inputs = inputs;
        }

        public void RegisterOpenWindow(object windowToken)
        {
            bool wasEmpty = _activeWindows.Count == 0;
            _activeWindows.Add(windowToken);

            if (wasEmpty && _activeWindows.Count > 0)
            {
                _inputs.SetHUDMode();
            }
        }

        public void UnregisterOpenWindow(object windowToken)
        {
            _activeWindows.Remove(windowToken);

            if (_activeWindows.Count == 0)
            {
                _inputs.SetGameplayMode();
            }
        }
    }
}