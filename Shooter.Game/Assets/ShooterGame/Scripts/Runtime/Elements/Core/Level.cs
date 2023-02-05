using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class Level
    {

        public Action OnScoreChanged;
        public PlayerController Player;
        public LevelSettings LevelSettings;
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


        public Level(LevelSettings level)
        {
            Player = SpawnPlayer(level);
            Game.Instance.UnitManager.OnKillingBlowDealt += HandleKillingBlow;
            Game.Instance.UnitManager.SpawnUnit(level.EnemyDefinition, level.EnemySpawnPosition.transform.position);
        }

        public PlayerController SpawnPlayer(LevelSettings levelSettings)
        {
            LevelSettings = levelSettings;
            Player = Game.Instance.UnitManager.SpawnUnit(levelSettings.PlayerDef, levelSettings.PlayerStartPosition.transform.position) as PlayerController;
            return Player;
        }

        private void HandleKillingBlow(Damage killingBlow)
        {
            if (killingBlow.Source == Player && killingBlow.Target != Player)
                Score++;
        }
    }
}