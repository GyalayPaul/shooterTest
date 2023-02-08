using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Shooter.UI
{
    /// <summary>
    /// Class for handling the death screen which appears after the player has died and the level has ended.
    /// </summary>
    public class UIDeathScreen : MonoBehaviour
    {
        [SerializeField]
        protected Button RestartButton;
        [SerializeField]
        protected Button QuitButton;
        [SerializeField]
        protected TextMeshProUGUI ScoreLabel;

        public void ShowLevelInfo(Level level)
        {
            ScoreLabel.text = "Score: " + level.Score;
        }

        public void Awake()
        {
            RestartButton?.onClick.AddListener(ReloadGame);
            QuitButton?.onClick.AddListener(QuitGame);
        }

        private void QuitGame()
        {
            Application.Quit();
        }

        private void ReloadGame()
        {
            SceneManager.LoadScene(0);
        }

    }
}