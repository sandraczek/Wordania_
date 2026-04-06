using System;
using UnityEngine;

namespace Wordania.Core.Events
{
    public abstract class BaseSignal: ScriptableObject
    {
        private Action _onTriggered;

        public void Raise() => _onTriggered?.Invoke();

        public void Subscribe(Action listener) => _onTriggered += listener;
        public void Unsubscribe(Action listener) => _onTriggered -= listener;
    }
    public abstract class BaseSignal<T>: ScriptableObject
    {
        private Action<T> _onTriggered;

        public void Raise(T package) => _onTriggered?.Invoke(package);

        public void Subscribe(Action<T> listener) => _onTriggered += listener;
        public void Unsubscribe(Action<T> listener) => _onTriggered -= listener;
    }
}