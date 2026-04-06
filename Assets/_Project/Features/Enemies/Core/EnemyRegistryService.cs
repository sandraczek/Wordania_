using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using Wordania.Core.Gameplay;
using Wordania.Core.Services;
using Wordania.Features.Combat.Core;

namespace Wordania.Features.Enemies.Core
{
    public sealed class EnemyRegistryService : Registry<IEnemy>, IEnemyRegistryService
    {
        
    }
}