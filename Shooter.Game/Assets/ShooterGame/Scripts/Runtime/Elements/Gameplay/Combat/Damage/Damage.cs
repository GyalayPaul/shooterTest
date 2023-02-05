using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Shooter
{
    public enum DamageType
    {
        Ranged = 1,
        Melee = 2,
    }
    /// <summary>
    /// Class that handles created instances of damage. Can be extended to handle on-hit effects and actions if needed, and just transmit base attack information in
    /// case there'll be stats such as resistances to certain types of damage or buffs to certain types of damage. Also stores the source of the damage and 
    /// the target in case this information is needed elswhere. Scource can be extended if we need to track specific things like what weapon was used, or if we want to track how many kills with a weapon the player has.  
    /// </summary>
    public class Damage
    {
        public UnitController Source;
        public UnitController Target = null;
        public int Value;
        public DamageType Type;

        public Damage(int value, UnitController source, DamageType type)
        {
            Source = source;
            Type = type;
            Value = value;
        }
        public void Apply(UnitController target)
        {
            Target = target;
            target.ApplyDamage(this);
        }

        public override String ToString()
        {
            return Type.ToString() + " damage from " + Source?.ToString();
        }
    }
}