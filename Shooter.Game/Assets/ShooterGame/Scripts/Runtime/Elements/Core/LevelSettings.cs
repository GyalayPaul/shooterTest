using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class LevelSettings : MonoBehaviour
    {
        public Transform PlayerStartPosition;
        public Transform EnemySpawnPosition; 
        public WeaponDefinition PlayerStartingWeapon;
        public PlayerStartDefinition PlayerDef;
        public UnitDefinition EnemyDefinition; 


        public void Awake()
        {
            Game.Instance.LevelManager.StartLevel(this);
        }
    }
}