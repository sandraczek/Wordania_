using System;
using UnityEngine;

namespace Wordania.Features.Inventory
{
    public interface IItemDatabase
    {
        ItemData GetItem(string id);
    }
}