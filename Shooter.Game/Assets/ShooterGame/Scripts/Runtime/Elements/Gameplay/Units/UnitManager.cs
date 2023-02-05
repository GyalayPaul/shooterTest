using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class UnitManager : MonoBehaviour
    {
        public Action<Damage> OnKillingBlowDealt; 
        public UnitController SpawnUnit(UnitDefinition unit, Vector3 position)
        {
            var spawnedUnit = Instantiate(unit.Prefab, transform);
            spawnedUnit.transform.position = position;
            spawnedUnit.Init(unit);
            return spawnedUnit;
        }

        public void RegisterUnitDeath(UnitController unit, Damage killingBlow)
        {
            Debug.Log("[Unit Manager] :  Unit " + unit.gameObject.name +  "was killed by " + killingBlow.ToString());
            OnKillingBlowDealt?.Invoke(killingBlow);
        }

    }
}