using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class UnitController : MonoBehaviour, IDamageable
    {
        public UnitModel Model;
        public UnitView View;

        public virtual void Init(UnitDefinition definition)
        {
            Model = new UnitModel(definition,this);
            Model.OnDeath += Die;
        }

        public virtual void ApplyDamage(Damage damage)
        {
            Model.ApplyDamage(damage);
        }

        public virtual void Die(Damage damageSource)
        {
            Game.Instance.UnitManager.RegisterUnitDeath(this, damageSource);
            Destroy(gameObject);
        }
    }
}