using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wordania.Core.Identifiers;

namespace Wordania.Features.Inventory
{
    public interface IInventoryService
    {
        event Action OnInventoryChanged;

        void AddItem(AssetId itemId, int amount);
        bool RemoveItem(AssetId itemId, int amount);
        int GetQuantity(AssetId itemId);
        IEnumerable<InventoryEntry> GetAllEntries();
    }
}