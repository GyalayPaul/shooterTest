using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Shooter
{
    [CreateAssetMenu(fileName = "Units", menuName = "ScriptableObjects/Unit")]
    public class UnitDefinition : ScriptableObject
    {
        public int BaseMaxHealth =100;
        public int BaseStartingHealth = 100;
        public int BaseMovementSpeed = 10;

        public UnitController Prefab; 
    }
}