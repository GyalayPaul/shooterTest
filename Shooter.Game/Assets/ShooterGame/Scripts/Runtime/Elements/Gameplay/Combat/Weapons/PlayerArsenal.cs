using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class PlayerArsenal
    {
        public Unit Owner;
        public Transform ArsenalParent;
        public List<WeaponController> Weapons = new List<WeaponController>();
        public WeaponController EquippedWeapon = null;
        public Action<WeaponController> OnWeaponAddedToArsenal;
        public Action<WeaponController> OnWeaponEquipped;

        public void AddWeapon(WeaponDefinition definition)
        {
            var weaponController = UnityEngine.Object.Instantiate(definition.ModelPrefab, ArsenalParent);
            weaponController.InitWeapon(definition);
            
            Weapons.Add(weaponController);
            OnWeaponAddedToArsenal?.Invoke(weaponController);

            if (EquippedWeapon == null)
            {
                EquippedWeapon = weaponController;
                OnWeaponEquipped?.Invoke(weaponController);
            }
        }
        public PlayerArsenal(Unit owner, Transform weaponParent)
        {
            Owner = owner;
            ArsenalParent = weaponParent;
        }
    }
}