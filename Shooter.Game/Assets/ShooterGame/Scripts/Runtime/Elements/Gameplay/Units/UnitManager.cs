using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public enum Faction
    {
        None,
        Player = 1,
        Enemy = 2,
        Friendly = 3,
    }

    public class UnitManager : MonoBehaviour
    {
        public Action<Damage> OnKillingBlowDealt;
        public List<UnitController> Units = new List<UnitController>();

        public AgentController SpawnEnemy(AgentDefinition unitDef, EnemySpawner spawner)
        {
            var Agent = SpawnUnit(unitDef, spawner.SpawnTransform.position) as AgentController;
            Agent.PatrolComponent.SetPatrol(spawner.PotentialPatrols[UnityEngine.Random.Range(0, spawner.PotentialPatrols.Count)].Waypoints);
            return Agent;
        }

        public UnitController SpawnUnit(UnitDefinition unit, Vector3 position)
        {
            var spawnedUnit = Instantiate(unit.Prefab, transform);
            spawnedUnit.transform.position = position;
            spawnedUnit.Init(unit);
            spawnedUnit.OnDeath += RegisterUnitDeath;
            Units.Add(spawnedUnit);
            
            return spawnedUnit;
        }


        public void RegisterUnitDeath(Damage killingBlow)
        {
            var unit = killingBlow.Target;
            Debug.Log("[Unit Manager] :  Unit " + unit.gameObject.name + "was killed by " + killingBlow.ToString());
            OnKillingBlowDealt?.Invoke(killingBlow);
            Units.Remove(unit);
        }

    }
}