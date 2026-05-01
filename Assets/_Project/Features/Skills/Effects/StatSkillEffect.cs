using System;
using UnityEngine;
using Wordania.Core.Gameplay;
using Wordania.Core.Identifiers;
using Wordania.Core.Stats;
using Wordania.Features.Player;

namespace Wordania.Features.Skills.Effects
{
    [Serializable]
    public class StatSkillEffect : ISkillEffect
    {
        [field: SerializeField] public StatType TargetStat { get; private set; }
        [field: SerializeField] public StatModifierType ModifierType { get; private set; }
        [field: SerializeField] public float Value { get; private set; }

        public void Apply(IPlayerSkillContext context, AssetId source)
        {
            var modifier = new StatModifier(Value, ModifierType, source);
            context.AddModifier(TargetStat, modifier);
        }

        public void Revert(IPlayerSkillContext context, AssetId source)
        {
            context.RemoveModifiers(TargetStat, source);
        }
    }
}