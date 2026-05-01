using Wordania.Core.Identifiers;
using Wordania.Core.Stats;

namespace Wordania.Core.Gameplay
{
    public interface IPlayerSkillContext
    {
        void UnlockMechanic(AssetId mechanicId);
        void LockMechanic(AssetId mechanicId);
        void AddModifier(StatType type, StatModifier modifier);
        void RemoveModifiers(StatType type, AssetId modifier);
    }
}