using UnityEngine;
using Wordania.Core.Data;
namespace Wordania.Features.Inventory
{
    [CreateAssetMenu(fileName = "ItemRegistry", menuName = "Inventory/Item Registry")]
    public sealed class ItemRegistry : AssetRegistry<ItemData>
    {
        
    }
}