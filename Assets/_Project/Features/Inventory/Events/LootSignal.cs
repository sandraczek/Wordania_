using UnityEngine;
using System;
using Wordania.Features.Inventory;
using Wordania.Core.Events;

namespace Wordania.Features.Inventory.Events
{
    public struct LootData
    {
        public ItemData Item;
        public int Quantity;
        public LootData(ItemData item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
    }
    
    [CreateAssetMenu(menuName = "Signals/Loot Signal")]
    public sealed class LootSignal : BaseSignal<LootData>
    {

    }
}