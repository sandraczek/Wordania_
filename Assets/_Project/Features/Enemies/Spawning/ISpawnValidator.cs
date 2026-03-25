using UnityEngine;
using Wordania.Features.Enemies.Data;

namespace Wordania.Features.Enemies.Spawning
{
    public interface ISpawnValidator
    {
        bool IsValid(in EnemyTemplate template, Vector2 position);
    }
}