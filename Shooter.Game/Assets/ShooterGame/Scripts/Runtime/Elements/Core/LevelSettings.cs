using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{

    [Serializable]
    public class Patrol
    {
        public List<Transform> Waypoints;
    }

    [Serializable]
    public class EnemySpawner
    {
        public Transform SpawnTransform;
        public List<Patrol> PotentialPatrols;
    }
    public class LevelSettings : MonoBehaviour
    {
        public Transform PlayerStartPosition;
        public Transform EnemySpawnPosition; 
        public WeaponDefinition PlayerStartingWeapon;
        public PlayerStartDefinition PlayerDef;
        public AgentDefinition EnemyDefinition;

        public List<EnemySpawner> Spawners; 
        public void Awake()
        {
            Game.Instance.LevelManager.StartLevel(this);
        }
    }
}