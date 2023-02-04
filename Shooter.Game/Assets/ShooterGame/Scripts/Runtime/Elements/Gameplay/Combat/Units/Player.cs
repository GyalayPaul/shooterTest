using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Shooter
{
    public class Player : Unit
    {
        public PlayerArsenal Arsenal;


        public WeaponController EquippedWeapon => Arsenal.EquippedWeapon;


        public WeaponDefinition startingWeaponDefinition;

        [SerializeField]
        private InputActionReference shoot, reload;

        [SerializeField]
        private Transform weaponParent;
        public void Awake()
        {
            Health = new Stat();
            Arsenal = new PlayerArsenal(this, weaponParent);
            Arsenal.AddWeapon(startingWeaponDefinition);
        }

        public void OnEnable()
        {
            shoot.action.performed += ShootWeapon;
            reload.action.performed += ReloadWeapon;
        }

        public void OnDisable()
        {
            shoot.action.performed -= ShootWeapon;
            reload.action.performed -= ReloadWeapon;
        }

        private void ShootWeapon(InputAction.CallbackContext obj)
        {
            EquippedWeapon?.HandleWeaponShootInput();
        }
        private void ReloadWeapon(InputAction.CallbackContext obj)
        {
            EquippedWeapon?.HandleWeaponReloadInput();
        }



    }
}