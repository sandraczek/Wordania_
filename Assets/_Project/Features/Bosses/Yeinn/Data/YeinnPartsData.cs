using System;
using UnityEngine;
using Wordania.Features.Bosses.Data;
using Wordania.Features.Bosses.Data.SharedAttacks;

namespace Wordania.Features.Bosses.Yeinn.Data
{
    [Serializable]
    public sealed class YeinnHeadData : BossPartData
    {
        [field: SerializeField] public SlamPlayerAttack Slam { get;private set; }
    }
    [Serializable]
    public sealed class YeinnHandData : BossPartData
    {
        [field: SerializeField] public SlamPlayerAttack Slam { get;private set; }
        [field: SerializeField] public SwipePlayerAttack Swipe { get;private set; }
    }
}