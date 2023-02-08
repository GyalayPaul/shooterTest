using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Shooter
{
    /// <summary>
    /// Definition Class for units containing basic info such as health, prefab , faction and IDs.
    /// </summary>
    [CreateAssetMenu(fileName = "Units", menuName = "ScriptableObjects/Units/Generic Unit")]
    public class UnitDefinition : ScriptableObject
    {
        public string Id = "";
        public int BaseMaxHealth =100;
        public int BaseStartingHealth = 100;
        public int BaseMovementSpeed = 10;

        public UnitController Prefab;
        public Faction Faction;
    }
}