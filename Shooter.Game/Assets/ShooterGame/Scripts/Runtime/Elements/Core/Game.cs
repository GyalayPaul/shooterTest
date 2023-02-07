using Shooter.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Shooter
{
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
        public void Start()
        {
        }
    }
}