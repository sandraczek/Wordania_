namespace Wordania.Core.HUD
{
    public interface IHUDStateManager
    {
        void RegisterOpenWindow(object windowToken);
        void UnregisterOpenWindow(object windowToken);
    }
}