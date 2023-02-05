using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public interface IDamageable
    {
        public void ApplyDamage(Damage damage);

        public void Die(Damage damageSource);
    }
}