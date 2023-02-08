using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
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