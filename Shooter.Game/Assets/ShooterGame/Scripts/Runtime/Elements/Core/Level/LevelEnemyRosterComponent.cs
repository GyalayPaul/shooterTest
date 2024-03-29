using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    /// <summary>
    /// Class that handles enemy respawning for an active level.
    /// </summary>
    public class LevelEnemyRosterComponent
    {
        protected Level Level;
        protected List<EnemyRosterEntry> Entries;
        protected List<EnemySpawner> Spawners;
        public LevelEnemyRosterComponent(Level level, List<EnemyRosterEntry> entries, List<EnemySpawner> spawners)
        {
            Level = level;
            Entries = entries;
            Spawners = spawners;
        }
        /// <summary>
        /// Checks to see if should spawn enemies to match desired roster enemy ammounts. 
        /// </summary>
        public void UpdateEnemies()
        {
            foreach (var entry in Entries)
            {
                while (Level.UnitManager.GetUnitsOfType(entry.Agent) < entry.Quantity)
                {
                    Level.UnitManager.SpawnEnemy(entry.Agent, GetRandomSpawner());
                }
            }
        }
        protected EnemySpawner GetRandomSpawner()
        {
            return Spawners[Random.Range(0, Spawners.Count)];
        }
    }
}