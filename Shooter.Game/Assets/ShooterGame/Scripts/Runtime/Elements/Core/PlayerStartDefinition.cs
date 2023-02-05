using Shooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Shooter
{
    [CreateAssetMenu(fileName = "PlayerSetup", menuName = "ScriptableObjects/PlayerSetup")]
    public class PlayerStartDefinition : UnitDefinition
    {
        public WeaponDefinition StartingWeapon; 
    }
}