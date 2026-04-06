using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using System;



#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Wordania.Features.World
{
    [CreateAssetMenu(fileName = "BlockRegistry", menuName = "World/Block Registry")]
    public sealed class BlockRegistry : ScriptableObject, IBlockDatabase
    {
        [SerializeField]
        private List<BlockData> _allBlocks = new();
        private Dictionary<int, BlockData> _blockMap;
        [SerializeField] TileBase[] _crackTiles;

        public void Initialize()
        {

            _blockMap = new Dictionary<int, BlockData>(_allBlocks.Count);

            foreach (var block in _allBlocks)
            {
                if (block == null) continue;

                if (!_blockMap.TryAdd(block.ID, block))
                {
                    Debug.LogWarning($"[BlockDatabase] Duplicated ID: {block.ID} for block {block.name}.");
                }
            }
        }
        public void InitializeOld()
        {
            _blockMap = new Dictionary<int, BlockData>();
            foreach (var block in _allBlocks)
            {
                if (block != null) _blockMap.TryAdd(block.ID, block);
            }
        }

        public BlockData GetBlock(int id)
        {
            if(id==0) return null;
            if (_blockMap.TryGetValue(id, out var block)) return block;
            else Debug.LogError("No id " + id + " in block database");
            return null;
        }
        public TileBase GetCracks(float damage)
        {
            if (damage >= 1f) return null;

            int index = Mathf.FloorToInt((damage + 0.01f)* (_crackTiles.Length + 1 ));
            index = Mathf.Clamp(index, 0, _crackTiles.Length);
            if(index == 0) return null;

            return _crackTiles[index - 1];
        }

        #if UNITY_EDITOR
        [ContextMenu("Auto-Find All Blocks")]
        public void FindAllBlocksInProject()
        {
            _allBlocks ??= new();
            _allBlocks.Clear();

            string[] guids = AssetDatabase.FindAssets("t:BlockData");

            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                BlockData block = AssetDatabase.LoadAssetAtPath<BlockData>(path);
                
                if (block != null)
                {
                    _allBlocks.Add(block);
                }
            }
            
            Debug.Log($"Success! Found and added {_allBlocks.Count} blocks to database.");
            
            EditorUtility.SetDirty(this); 
        }
        #endif
    }
}

// using UnityEngine;
// using Wordania.Core.Data;

// namespace Wordania.Features.World
// {
//     [CreateAssetMenu(fileName = "BlockDatabase", menuName = "World/Block Database")]
//     public sealed class BlockDatabase : AssetDatabase<BlockData>
//     {
        
//     }
// }