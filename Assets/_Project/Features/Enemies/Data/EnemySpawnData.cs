using System;
using UnityEngine;

namespace Wordania.Features.Enemies.Data
{
    [Serializable]
    public class EnemySpawnData
    {
        [SerializeField] public bool RequiresGround = true;
        [SerializeField] public float MaxDistanceToGround = 0.5f;
        [SerializeField] public Vector2 RequiredClearanceSize;
        [SerializeField] public Vector2 ClearancePadding = new(0.2f,0.2f);
    }
}