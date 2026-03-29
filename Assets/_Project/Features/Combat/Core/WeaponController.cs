using System.Collections.Generic;
using UnityEngine;
using VContainer;
using Wordania.Core;
using Wordania.Core.Inputs;
using Wordania.Features.Combat.Data;
using Wordania.Features.Combat.FireStrategies;

namespace Wordania.Features.Combat.Core
{
    public class WeaponController : MonoBehaviour
    {
        private IWeaponFireStrategy _strategy;
        private ProjectileFiredSignal _firedSignal;

        private float _lastFiredTime = float. MinValue;
            
        private readonly List<ProjectileSpawnData> _spawnBuffer = new(capacity: 20);

        [Inject]
        public void Construct(ProjectileFiredSignal firedSignal)
        {
            _firedSignal = firedSignal;
            _strategy = new StraightFireStrategy(); // DEBUG
        }
        public bool Fire(Vector2 position, Vector2 direction, WeaponData data)
        {
            if(Time.time < _lastFiredTime + data.FireRate) return false;
            
            _lastFiredTime = Time.time;
            _spawnBuffer.Clear();

            int projectilesToSpawn = _strategy.CalculateFireData(position, direction, data, _spawnBuffer);

            for (int i = 0; i < projectilesToSpawn; i++)
            {
                _firedSignal.Raise(_spawnBuffer[i]);
            }

            return true;
        }
    }
}