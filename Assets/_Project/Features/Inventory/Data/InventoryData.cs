using UnityEngine;
using System;
using System.Collections.Generic;
using VContainer;
using Wordania.Core.Identifiers;

namespace Wordania.Features.Inventory
{
    public sealed class InventoryData
    {
        public readonly Dictionary<AssetId, InventoryEntry> _content = new();
    }
}