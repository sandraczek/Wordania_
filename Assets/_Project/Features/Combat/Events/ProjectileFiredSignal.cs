using System;
using UnityEngine;
using Wordania.Core.Events;
using Wordania.Features.Combat.Data;

namespace Wordania.Features.Combat.Events
{
    [CreateAssetMenu(menuName = "Signals/ProjectileFired")]
    public sealed class ProjectileFiredSignal : BaseSignal<ProjectileSpawnData>
    {

    }
}