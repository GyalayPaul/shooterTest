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

    [Serializable]
    public class EnemyRosterEntry
    {
        public AgentDefinition Agent;
        public int Quantity; 
    }
    public class LevelSettings : MonoBehaviour
    {
        public Transform PlayerStartPosition;
        public PlayerStartDefinition PlayerDef;

        public List<EnemyRosterEntry> EnemyRoster; 
        public List<EnemySpawner> Spawners; 
        public void Awake()
        {
            Game.Instance.LevelManager.StartLevel(this);
        }
    }
}