using UnityEngine;

namespace Wordania.Features.Player.Interaction
{
    public interface IItemActionExecutor
    {
        public bool ExecutePrimaryAction(Vector2 targetWorldPos, int instigatorId);
        public bool ExecuteSecondaryAction(Vector2 targetWorldPos, int instigatorId);
        void ReleasePrimaryAction();
    }
}