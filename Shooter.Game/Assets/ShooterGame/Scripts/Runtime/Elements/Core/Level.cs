using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class Level
    {
        public Player Player;
        public Action OnScoreChanged;
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
    

    }
}