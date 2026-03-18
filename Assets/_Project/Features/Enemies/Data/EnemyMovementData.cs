using System;
using UnityEngine;
using Wordania.Gameplay.Inventory;
using Wordania.Gameplay.Movement;

namespace Wordania.Gameplay.Enemies.Data
{
    [Serializable]
    public sealed class EnemyMovementData
    {
        [SerializeField] public float GravityScale = 5f;
        [SerializeField] public float AccelerationSpeed = 0.2f;
        [SerializeField] public float StoppingSpeed = 0.1f;
        [field: SerializeField, Range(0.1f, 50f)] public float PatrolSpeed { get; private set; } = 2f;
        [SerializeField] public float PatrolIntervalTime = 5f;
        [field: SerializeField, Range(0.1f, 50f)] public float ChaseSpeed { get; private set; } = 4.5f;
        [field: SerializeField, Range(0f, 50f)] public float JumpForce { get; private set; } = 10f;
        [SerializeField] public LayerMask GroundLayer;
        [SerializeField] public float GroundCheckSizeY = 0.1f;
        [SerializeField] public float GroundCheckDistance = 0.2f;
        [SerializeField] public float MaxStepHeight = 1.1f;
        [SerializeField] public float StepLookDistance = 0.2f;
        [field: SerializeField] public bool AvoidsLedges { get; private set; } = true;
        [field: SerializeField] public float FallDamageThreshold;// = 60f;
        [field: SerializeField] public float FallDamageMultiplier;// = 2.5f;
    }
}