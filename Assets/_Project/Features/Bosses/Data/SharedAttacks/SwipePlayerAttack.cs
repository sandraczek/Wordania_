using System;

namespace Wordania.Features.Bosses.Data.SharedAttacks
{
    [Serializable]
    public struct SwipePlayerAttack
    {
        public float TimeToAttack;
        public float DistanceFromPlayer;
        public float AttackDistance;
        public float Speed;
    }
}