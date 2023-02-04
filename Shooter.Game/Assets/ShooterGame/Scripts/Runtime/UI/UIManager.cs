using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.UI
{
    public class UIManager : MonoBehaviour
    {
        public UIHudScreen HUDScreen;
        public UIDeathScreen DeathScreen;

        public void Awake()
        {
            Game.Instance.LevelManager.OnLevelStarted += LevelStartUIInit;
        }

        public void LevelStartUIInit()
        {
            HUDScreen.Show(Game.Instance.LevelManager.ActiveLevel);
            DeathScreen.gameObject.SetActive(false);
        }
    }
}