using System;
using UnityEngine;
using Wordania.Core.Gameplay;
using Wordania.Core.Identifiers;
using Wordania.Features.Player;

namespace Wordania.Features.Skills.Effects
{
    [Serializable]
    public class UnlockMechanicSkillEffect : ISkillEffect
    {
        [field: SerializeField] public AssetId MechanicId { get; private set; }

        public void Apply(IPlayerSkillContext context, AssetId source)
        {
            context.UnlockMechanic(MechanicId);
        }

        public void Revert(IPlayerSkillContext context, AssetId source)
        {
            context.LockMechanic(MechanicId);
        }
    }
}