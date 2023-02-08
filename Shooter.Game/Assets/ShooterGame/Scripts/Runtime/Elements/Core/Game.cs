using Shooter.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Shooter
{
    /// <summary>
    /// Singleton-ish class used to handle the links between ui and game logic through the level manager. 
    /// </summary>
    public class Game : MonoBehaviour
    {
        public static Game Instance;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        public UIManager UIManager;
        public LevelManager LevelManager;
    }
}