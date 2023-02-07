using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace Shooter.UI
{
    public class UIWeaponDisplay : MonoBehaviour
    {

        protected WeaponController CurrentWeapon { get; set; } = null;
        [SerializeField]
        protected TextMeshProUGUI AmmoLabel;
        [SerializeField]
        protected Image AmmoBarFill;

        protected const float BAR_ANIMATION_DURATION = 0.25f;

        public void Awake()
        {
            if (AmmoLabel == null) Debug.LogError("UIWeaponDisplay: AmmoLabel is not assigned!");
            if (AmmoBarFill == null) Debug.LogError("UIWeaponDisplay: AmmoBarFill is not assigned!");
        }
        public void ShowWeapon(WeaponController weapon)
        {
            if (weapon != CurrentWeapon)
            {
                ClearWeapon();
                CurrentWeapon = weapon;
                weapon.OnWeaponShot += RefreshWeaponDisplay;
                weapon.OnWeaponReloadEnd += RefreshWeaponDisplay;
            }
            RefreshWeaponDisplay();
        }
        public void ClearWeapon()
        {
            if (CurrentWeapon != null)
            {
                CurrentWeapon.OnWeaponShot -= RefreshWeaponDisplay;
                CurrentWeapon.OnWeaponReloadEnd -= RefreshWeaponDisplay;
                CurrentWeapon = null;
            }
        }
        public void RefreshWeaponDisplay()
        {
            if (CurrentWeapon != null)
            {
                UpdateAmmoBar();
                UpdateAmmoLabel();
            }
        }
        protected void UpdateAmmoLabel()
        {
            AmmoLabel.text = CurrentWeapon.Model.CurrentMagazineAmmo + "/" + CurrentWeapon.Model.CurrentStoredAmmo;
        }
        protected void UpdateAmmoBar()
        {
            AmmoBarFill.DOKill(false);
            AmmoBarFill.DOFillAmount((float) CurrentWeapon.Model.CurrentMagazineAmmo / (float) CurrentWeapon.Model.Definition.BaseMagazineAmmoCapacity, BAR_ANIMATION_DURATION);
        }
    }
}