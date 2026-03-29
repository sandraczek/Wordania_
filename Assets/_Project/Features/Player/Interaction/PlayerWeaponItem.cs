using UnityEngine;
using Wordania.Features.Combat.Core;
using Wordania.Features.Combat.Data;

namespace Wordania.Features.Player.Interaction
{
    [RequireComponent(typeof(WeaponController))]
    public class PlayerWeaponItem : MonoBehaviour, IItemActionExecutor
    {
        private WeaponController _weaponController;
        private Transform _barrelTransform;
        [SerializeField] private WeaponData _weaponConfig;

        private void Awake()
        {
            _weaponController = GetComponent<WeaponController>();
            _barrelTransform = gameObject.transform; // for now
        }
        public bool ExecutePrimaryAction(Vector2 targetWorldPos)
        {
            Vector2 aimDirection = (targetWorldPos - (Vector2)_barrelTransform.position).normalized;

            return _weaponController.Fire(_barrelTransform.position, aimDirection, _weaponConfig);
        }
        public bool ExecuteSecondaryAction(Vector2 targetWorldPos) {return false;}

        public void ReleasePrimaryAction() { }
    }
}