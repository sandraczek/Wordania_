using System;
using System.Diagnostics;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Wordania.Core.Config;
using Wordania.Core.Mapping;
using Wordania.Gameplay.World;

namespace Wordania.Gameplay.Mapping
{
    public interface IMapUpdateService
    {
        public UniTask RenderInitialMapAsync(CancellationToken token);
    }
}