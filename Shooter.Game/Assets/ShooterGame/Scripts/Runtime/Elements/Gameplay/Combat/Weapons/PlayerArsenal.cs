using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class PlayerArsenal
    {
        public UnitController Owner;
        public Transform ArsenalParent;
        public List<WeaponController> Weapons = new List<WeaponController>();
        public WeaponController EquippedWeapon = null;
        public Action<WeaponController> OnWeaponAddedToArsenal;
        public Action<WeaponController> OnWeaponEquipped;

        public void AddWeapon(WeaponDefinition definition)
        {
            var weaponController = UnityEngine.Object.Instantiate(definition.ModelPrefab, ArsenalParent);
            weaponController.InitWeapon(definition,Owner);
            
            Weapons.Add(weaponController);
            OnWeaponAddedToArsenal?.Invoke(weaponController);

            if (EquippedWeapon == null)
            {
                EquippedWeapon = weaponController;
                OnWeaponEquipped?.Invoke(weaponController);
            }
        }
        public PlayerArsenal(UnitController owner, Transform weaponParent)
        {
            Owner = owner;
            ArsenalParent = weaponParent;
        }
    }
}