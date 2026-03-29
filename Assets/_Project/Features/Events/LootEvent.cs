using UnityEngine;
using System;
using Wordania.Features.Inventory;

namespace Wordania.Features.Events
{
    [CreateAssetMenu(menuName = "Signals/Loot Event")]
    public sealed class LootEvent : ScriptableObject
    {
        private Action<ItemData, int> _onLootTriggered;

        public void Raise(ItemData item, int amount) => _onLootTriggered?.Invoke(item, amount);

        public void Subscribe(Action<ItemData, int> listener) => _onLootTriggered += listener;
        public void Unsubscribe(Action<ItemData, int> listener) => _onLootTriggered -= listener;
    }
}