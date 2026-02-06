using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Wordania.Core.Gameplay
{
    public interface IPlayerProvider
    {
        Transform PlayerTransform { get; }
        bool IsPlayerSpawned { get; }
    }
}