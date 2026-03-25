

using Cysharp.Threading.Tasks;

namespace Wordania.Features.HUD.Loading
{
    public interface ILoadingScreenService
    {
        void Show();
        void UpdateProgress(float progress, string message = "");
        UniTask Hide();
    }
}