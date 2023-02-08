using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.UI
{
    /// <summary>
    /// Class used to show the HUD screen of a player in a given level.
    /// </summary>
    public class UIHudScreen : MonoBehaviour
    {
        [SerializeField]
        protected UIScoreDisplay ScoreDisplay;
        [SerializeField]
        protected UIHealthDisplay HealthDisplay;
        [SerializeField]
        protected UIWeaponDisplay WeaponDisplay;

        public void Show(Level level)
        {
            ScoreDisplay.ShowLevel(level);
            HealthDisplay.ShowUnit(level.Player);
            WeaponDisplay.ShowWeapon(level.Player.PlayerModel.Arsenal.EquippedWeapon);
        }
    }
}