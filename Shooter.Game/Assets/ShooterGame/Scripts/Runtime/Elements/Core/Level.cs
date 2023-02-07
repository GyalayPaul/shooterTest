using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class Level : MonoBehaviour
    {
        public Action OnScoreChanged;
        public Action OnLevelEnded;
        public PlayerController Player;
        public LevelSettings LevelSettings;

        public UnitManager UnitManager;

        public int Score
        {
            get
            {
                return ScoreInternal;
            }
            set
            {
                ScoreInternal = value;
                OnScoreChanged?.Invoke();
            }
        }
        protected int ScoreInternal = 0;

        public void Init(LevelSettings level)
        {
            InitUnitManager();
            Player = SpawnPlayer(level);
            foreach (var spawner in level.Spawners)
            {
                UnitManager.SpawnEnemy(level.EnemyDefinition, spawner);
            }
        }

        private void InitUnitManager()
        {
            var go = new GameObject("UnitManager");
            go.transform.parent = transform;
            UnitManager = go.AddComponent<UnitManager>();
            UnitManager.OnKillingBlowDealt += HandleKillingBlow;
        }

        public PlayerController SpawnPlayer(LevelSettings levelSettings)
        {
            LevelSettings = levelSettings;
            Player = UnitManager.SpawnUnit(levelSettings.PlayerDef, levelSettings.PlayerStartPosition.transform.position) as PlayerController;
            Player.OnDeath += (_) => { 
                EndLevel(); 
            };
            return Player;
        }

        private void HandleKillingBlow(Damage killingBlow)
        {
            if (killingBlow.Source == Player && killingBlow.Target != Player)
                Score++;
        }

        private void EndLevel()
        {
            OnLevelEnded?.Invoke();
        }
    }
}