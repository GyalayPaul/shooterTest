using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class LevelManager : MonoBehaviour
    {
        public Level ActiveLevel=null;
        public Action OnLevelStarted; 

        public void StartLevel()
        {
            ActiveLevel = new Level();
            ActiveLevel.Player = Game.Instance.Player;

            OnLevelStarted?.Invoke();
        }
    }
}