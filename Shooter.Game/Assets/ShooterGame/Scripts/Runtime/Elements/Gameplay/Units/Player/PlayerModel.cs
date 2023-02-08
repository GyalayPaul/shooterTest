using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    /// <summary>
    /// Model class for the player, contains an overriden constructor so that the player is initialized with at least 1 starter weapon, and contains the plyer arsenal class.
    /// </summary>
    public class PlayerModel : UnitModel
    {
        public PlayerArsenal Arsenal;
        public PlayerController PlayerController => Controller as PlayerController;

        public WeaponController EquippedWeapon => Arsenal.EquippedWeapon;

        public PlayerModel(UnitDefinition definition, PlayerController controller, WeaponDefinition startingWeaponDef) : base(definition, controller)
        {
            Definition = definition;
            Controller = controller;

            Arsenal = new PlayerArsenal(Controller, (Controller as PlayerController).WeaponParent);
            Arsenal.AddWeapon(startingWeaponDef);

            Health.OnMinValueReached += Die;
        }

    }
}