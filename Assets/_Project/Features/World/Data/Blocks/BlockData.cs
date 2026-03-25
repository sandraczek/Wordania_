using UnityEngine;
using UnityEngine.Tilemaps;
using Wordania.Gameplay.Inventory;

namespace Wordania.Gameplay.World
{
    [CreateAssetMenu(fileName = "NewBlock", menuName = "World/Block")]
    public sealed class BlockData : ScriptableObject
    {
        [Header("Id")]
        public int ID = -1;

        [Header("Visual")]
        public TileBase Tile;
        public Color32 MapColor = new(0,0,0,0);

        [Header("Stats")]
        public float Hardness = 1;
        
        [Header("Item Info")]
        public Recipe recipe;
        public ItemData loot;
        public int lootAmount;
    } 
}