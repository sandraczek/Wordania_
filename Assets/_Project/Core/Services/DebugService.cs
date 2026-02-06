using UnityEngine;

namespace Wordania.Core.Services
{
    public sealed class WordaniaDebugService : IDebugService
    {
        public void LogInformation(string message)
        {
            Debug.Log($"<color=#4AF626>[SYSTEM]:</color> {message}");
        }
    }
}