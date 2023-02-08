using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    /// <summary>
    /// Interface for things which can be damaged and destroyed, such as units and potentially other destructivble objects.
    /// </summary>
    public interface IDamageable
    {
        public void ApplyDamage(Damage damage);
        public void Die(Damage damageSource);
    }
}