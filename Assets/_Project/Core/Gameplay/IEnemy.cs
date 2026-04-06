using UnityEngine;
using Wordania.Core.Combat;
using Wordania.Core.Identifiers;

namespace Wordania.Core.Gameplay
{
    public interface IEnemy: IEntity
    {
        Vector2 Position { get; }
        bool IsAlive { get; }
        bool IsPersistent { get; }
        void Remove();
    }
}