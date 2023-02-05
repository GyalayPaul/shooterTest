using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Shooter
{
    public class WeaponModel
    {
        public WeaponController Controller; 
        public WeaponDefinition Definition { get; private set; }
        public int CurrentMagazineAmmo = 0;
        public int CurrentStoredAmmo = 0;

        public void Init(WeaponDefinition def)
        {
            Definition = def;
            CurrentMagazineAmmo = Definition.BaseMagazineAmmoCapacity;
            CurrentStoredAmmo = Definition.BaseMaxStoredAmmoCapacity;
        }
        public bool HasEnoughAmmoToShoot => CurrentMagazineAmmo >= Definition.BaseAmmoPerShot;
        public bool HasEnoughAmmoToReload => CurrentStoredAmmo > 0;
        public bool MagazineIsFull => CurrentMagazineAmmo == Definition.BaseMagazineAmmoCapacity;

        public void HandleShootCost()
        {
            CurrentMagazineAmmo -= Definition.BaseAmmoPerShot;
        }

        public void HandleReloadExchange()
        {
            var reloadValueNeeded = Definition.BaseMagazineAmmoCapacity - CurrentMagazineAmmo;
            CurrentStoredAmmo -= reloadValueNeeded;
            CurrentMagazineAmmo = Definition.BaseMagazineAmmoCapacity;
        }

        public WeaponModel(WeaponController controller, WeaponDefinition definition)
        {
            Controller = controller;
            Init(definition);
        }
        public Damage GetDamage()
        {
            return new Damage(Definition.BaseDamage, Controller.Wielder,   DamageType.Ranged);
        }
    }
}