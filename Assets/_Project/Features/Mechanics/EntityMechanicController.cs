using System;
using System.Collections.Generic;
using UnityEngine;
using Wordania.Core.Identifiers;

namespace Wordania.Features.Mechanics
{
    public class EntityMechanicController : MonoBehaviour
    {
        private readonly HashSet<AssetId> _activeMechanics = new();

        public event Action<AssetId> OnMechanicEnabled;
        public event Action<AssetId> OnMechanicDisabled;

        public void EnableMechanic(AssetId mechanicId)
        {
            if (_activeMechanics.Add(mechanicId))
            {
                OnMechanicEnabled?.Invoke(mechanicId);
            }
        }

        public void DisableMechanic(AssetId mechanicId)
        {
            if (_activeMechanics.Remove(mechanicId))
            {
                OnMechanicDisabled?.Invoke(mechanicId);
            }
        }

        public bool HasMechanic(AssetId mechanicId)
        {
            return _activeMechanics.Contains(mechanicId);
        }

        public void ClearAllMechanics()
        {
            var mechanicsToRemove = new List<AssetId>(_activeMechanics);

            foreach (var mechanicId in mechanicsToRemove)
            {
                DisableMechanic(mechanicId);
            }
        }
    }
}