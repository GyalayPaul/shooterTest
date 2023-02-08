using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace Shooter.UI
{
    /// <summary>
    /// Class used to show the score in a given level. 
    /// </summary>
    public class UIScoreDisplay : MonoBehaviour
    {

        [SerializeField]
        protected TextMeshProUGUI ScoreLabel;
        protected Level CurrentLevel;

        public void Awake()
        {
            if (ScoreLabel == null) Debug.LogError("UIScoreDisplay: ScoreLabel is not assigned!");
        }

        public void ShowLevel(Level level)
        {
            if (level != CurrentLevel)
            {
                CurrentLevel = level;
                CurrentLevel.OnScoreChanged += UpdateScore;
            }
            UpdateScore();
        }

        protected void UpdateScore()
        {
            ScoreLabel.text = CurrentLevel.Score.ToString();
        }
    }
}