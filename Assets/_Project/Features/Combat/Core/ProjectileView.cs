using System;
using UnityEngine;
using Wordania.Core.Identifiers;
using Wordania.Features.Combat.Data;

namespace Wordania.Core.Combat
{
    public sealed class ProjectileView : MonoBehaviour
    {
        [HideInInspector] public AssetId DataId;
    }
}