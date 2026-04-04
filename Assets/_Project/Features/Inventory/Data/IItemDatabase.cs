using System;
using UnityEngine;
using Wordania.Core.Identifiers;

namespace Wordania.Features.Inventory
{
    public interface IItemDatabase
    {
        ItemData GetItem(AssetId id);
    }
}