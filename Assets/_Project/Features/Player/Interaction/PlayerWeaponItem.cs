using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using Wordania.Core.Identifiers;
using Wordania.Features.Combat.Core;
using Wordania.Features.Combat.Data;

namespace Wordania.Features.Player.Interaction
{
    public class PlayerWeaponItem : MonoBehaviour, IItemActionExecutor // on player's hand
    {
        private WeaponController _weaponController;
        private Transform _barrelTransform;
        [SerializeField] private WeaponData _weaponConfig;

        private void Awake()
        {
            _weaponController = GetComponent<WeaponController>(); // later - will get the component from an item in inventory
            _barrelTransform = gameObject.transform; // for now
        }
        public bool ExecutePrimaryAction(Vector2 targetWorldPos, int instigatorId)
        {
            Vector2 aimDirection = (targetWorldPos - (Vector2)_barrelTransform.position).normalized;

            // ----------------------------- TEMPORARY NO DMG MULTIPLIER
            WeaponFireContext context = new()
                {
                    position = _barrelTransform.position,
                    direction = aimDirection,
                    weaponData = _weaponConfig,
                    damageMultiplier = 1f,
                    instigatorId = instigatorId,
                    TargetFactionMask = EntityFaction.Enemy
                };
            return _weaponController.Fire(context);
        }
        public bool ExecuteSecondaryAction(Vector2 targetWorldPos, int instigatorId) {return false;}

        public void ReleasePrimaryAction() { }
    }
}