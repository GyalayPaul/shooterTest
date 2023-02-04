using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter.UI
{
    public class UIDeathScreen : MonoBehaviour
    {
        [SerializeField]
        protected Button RestartButton;
        [SerializeField]
        protected Button QuitButton;

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

        }

    }
}