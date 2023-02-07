using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class LevelManager : MonoBehaviour
    {
        public Level ActiveLevel = null;
        public Action OnLevelStarted;
        public Action OnLevelEnded;

        public void StartLevel(LevelSettings levelSettings)
        {
            var go = new GameObject("Level");
            ActiveLevel = go.AddComponent<Level>();
            ActiveLevel.Init(levelSettings);
            ActiveLevel.gameObject.name = "LEVEL";
            OnLevelStarted?.Invoke();
            ActiveLevel.OnLevelEnded += OnLevelEnded;
        }
    }
}