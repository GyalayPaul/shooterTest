using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.UI
{
    /// <summary>
    /// Manager class for UI-related functionalities. Links up to the Game class for specific-ui-related events. 
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        public UIHudScreen HUDScreen;
        public UIDeathScreen DeathScreen;

        public void Awake()
        {
            Game.Instance.LevelManager.OnLevelStarted += LevelStartUIInit;
            Game.Instance.LevelManager.OnLevelEnded += LevelEndUI;
        }

        public void LevelStartUIInit()
        {
            HUDScreen.Show(Game.Instance.LevelManager.ActiveLevel);
            DeathScreen.gameObject.SetActive(false);
        }

        public void LevelEndUI()
        {
            HUDScreen.gameObject.SetActive(false);
            DeathScreen.gameObject.SetActive(true);
            DeathScreen.ShowLevelInfo(Game.Instance.LevelManager.ActiveLevel);
        }
    }
}