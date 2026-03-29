using UnityEngine;

namespace Wordania.Features.Player.Interaction
{
    public interface IItemActionExecutor
    {
        public bool ExecutePrimaryAction(Vector2 targetWorldPos);
        public bool ExecuteSecondaryAction(Vector2 targetWorldPos);
        void ReleasePrimaryAction();
    }
}