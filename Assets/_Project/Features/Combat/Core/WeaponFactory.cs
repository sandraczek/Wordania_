using log4net.Util;
using Wordania.Features.Combat.Data;

namespace Wordania.Features.Combat.Core
{
    public class WeaponFactory
    {
        // // ... pool injection ...

        // public WeaponController EquipWeapon(WeaponData data, Transform handTransform)
        // {
        //     WeaponController weaponView = _weaponPool.Get();
        //     weaponView.transform.SetParent(handTransform);

        //     // 2. Resolve the correct strategy (Pure C#, no MonoBehaviour!)
        //     IWeaponFireStrategy strategy = ResolveStrategy(config.StrategyType);

        //     // 3. Inject data and logic into the dumb view
        //     weaponView.Initialize(config, strategy);

        //     return weaponView;
        // }

        // private IWeaponFireStrategy ResolveStrategy(WeaponFireStrategyType type)
        // {
        //     // In a real AAA project, this would be handled by a DI Container (Zenject/VContainer)
        //     // or a Strategy Factory to avoid switch statements.
        //     return type switch
        //     {
        //         WeaponFireStrategyType.SingleShot => new SingleShotFireStrategy(),
        //         WeaponFireStrategyType.ShotgunSpread => new ShotgunFireStrategy(),
        //         _ => throw new ArgumentOutOfRangeException()
        //     };
        // }
    }
}