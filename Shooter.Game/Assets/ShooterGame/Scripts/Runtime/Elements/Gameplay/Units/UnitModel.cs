using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class UnitModel
    {
        public UnitController Controller;
        public UnitDefinition Definition;
        public Stat Health;
        public Action<Damage> OnDeath = null;

        private Damage lastDamageApplied = null;

        public UnitModel(UnitDefinition definition, UnitController controller)
        {
            Definition = definition;
            Controller = controller;
            Health = new Stat(definition.BaseMaxHealth, definition.BaseStartingHealth);
            Health.OnMinValueReached += Die;
        }

        public virtual void ApplyDamage(Damage damage)
        {
            Health.Change(-damage.Value);
            lastDamageApplied = damage;
        }

        public virtual void Die()
        {
            OnDeath?.Invoke(lastDamageApplied);
        }

    }
}