using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Wordania.Core.Identifiers;


#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Wordania.Features.Inventory
{
    [CreateAssetMenu(fileName = "ItemDataBase", menuName = "Inventory/Item Database")]
    public sealed class ItemDatabase : ScriptableObject, IItemDatabase
    {
        [SerializeField]
        private List<ItemData> _allItems = new();
        private Dictionary<AssetId, ItemData> _itemMap;

        public void Initialize()
        {
            _itemMap = new Dictionary<AssetId, ItemData>(_allItems.Count);
            foreach (var item in _allItems)
            {
                if (item == null) continue;
                if (!_itemMap.TryAdd(item.Id, item))
                {
                    Debug.LogWarning($"[ItemDatabase] Duplicated ID: {item.Id} for item {item.name}.");
                }
            }
        }
        public ItemData GetItem(AssetId id)
        {
            if(id.Hash==0) return null;
            if (_itemMap.TryGetValue(id, out var item)) return item;
            else Debug.LogError("No id " + id + "in item database");
            return null;
        }

        #if UNITY_EDITOR
        [ContextMenu("Auto-Find All Items")]
        public void FindAllItemsInProject()
        {
            _allItems.Clear();

            string[] guids = AssetDatabase.FindAssets("t:ItemData");

            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                ItemData item = AssetDatabase.LoadAssetAtPath<ItemData>(path);
                
                if (item != null)
                {
                    _allItems.Add(item);
                }
            }
            
            Debug.Log($"Success! Found and added {_allItems.Count} items to database.");
            
            EditorUtility.SetDirty(this); 
        }
        #endif
    }
}