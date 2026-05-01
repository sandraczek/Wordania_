using Wordania.Core.Gameplay;
using Wordania.Core.Identifiers;
using Wordania.Features.Player;

namespace Wordania.Features.Skills.Effects
{
    public interface ISkillEffect
    {
        /// <summary>
        /// Applies the effect to the provided player context.
        /// </summary>
        /// <param name="context">The facade exposing player capabilities.</param>
        /// <param name="source">The source of the effect, usually the skill's AssetId.</param>
        void Apply(IPlayerSkillContext context, AssetId source);

        /// <summary>
        /// Reverts the effect from the provided player context.
        /// </summary>
        /// <param name="context">The facade exposing player capabilities.</param>
        /// <param name="source">The source of the effect, usually the skill's AssetId.</param>
        void Revert(IPlayerSkillContext context, AssetId source);
    }
}