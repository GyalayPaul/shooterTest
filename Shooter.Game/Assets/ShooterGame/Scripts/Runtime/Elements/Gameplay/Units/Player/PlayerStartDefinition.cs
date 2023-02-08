using Shooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Shooter
{
    /// <summary>
    /// Definition of a player unit with a starting weapon.
    /// </summary>
    [CreateAssetMenu(fileName = "PlayerSetup", menuName = "ScriptableObjects/Units/Player")]
    public class PlayerStartDefinition : UnitDefinition
    {
        public WeaponDefinition StartingWeapon; 
    }
}