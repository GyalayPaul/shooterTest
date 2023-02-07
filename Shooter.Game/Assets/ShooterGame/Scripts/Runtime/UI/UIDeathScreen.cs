using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Shooter.UI
{
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