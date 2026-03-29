using System;
using UnityEngine;
using Wordania.Features.Combat.Data;

namespace Wordania.Core
{
    [CreateAssetMenu(menuName = "Signals/ProjectileFired")]
    public sealed class ProjectileFiredSignal : ScriptableObject
    {
        private Action<ProjectileSpawnData> _onTriggered;

        public void Raise(ProjectileSpawnData spawnData) => _onTriggered?.Invoke(spawnData);

        public void Subscribe(Action<ProjectileSpawnData> listener) => _onTriggered += listener;
        public void Unsubscribe(Action<ProjectileSpawnData> listener) => _onTriggered -= listener;
    }
}