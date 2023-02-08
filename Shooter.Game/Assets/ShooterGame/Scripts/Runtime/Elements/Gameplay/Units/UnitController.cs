using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    /// <summary>
    /// Generic controller for units, such as enemies or the player. Only contains basic information and should be inherited from for more specific types of units. 
    /// </summary>
    public class UnitController : MonoBehaviour, IDamageable
    {
        public UnitModel Model;
        public UnitView View;
        public Action<Damage> OnDeath;

        public virtual void Init(UnitDefinition definition)
        {
            Model = new UnitModel(definition, this);
            Model.OnDeath += Die;
            View.Controller = this;
        }

        public virtual void ApplyDamage(Damage damage)
        {
            if (Model.Alive)
                Model.ApplyDamage(damage);
        }

        public virtual void Die(Damage damageSource)
        {
            OnDeath?.Invoke(damageSource);
            Destroy(gameObject);
        }
    }
}