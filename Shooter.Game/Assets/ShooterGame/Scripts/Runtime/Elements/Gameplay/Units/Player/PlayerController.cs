using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter

{
    public class PlayerController : UnitController
    {
        public PlayerModel PlayerModel => Model as PlayerModel;
        public Transform WeaponParent;
        public PlayerInputComponent InputComponent;


        public override void Init(UnitDefinition playerDefinition)
        {
            
            var playerDef = playerDefinition as PlayerStartDefinition;
            if (WeaponParent != null)
                Model = new PlayerModel(playerDef, this, playerDef.StartingWeapon);
            else
            {
                Debug.LogError("PlayerController: Arsenal parent not assigned!");
            }

            if (InputComponent != null)
                InputComponent.Controller = this;
            else
            {
                Debug.LogError("PlayerController: InputComponent not assigned!");
            }

            Model.OnDeath += Die;

        }

        public override void Die(Damage damageSource)
        {
            InputComponent.enabled = false;
            OnDeath?.Invoke(damageSource);

        }

    }
}