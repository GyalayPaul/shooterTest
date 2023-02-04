using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class WeaponController : MonoBehaviour
    {
        public WeaponModel Model { get; protected set; }
        public WeaponView View;

        public Action OnWeaponShot = null;
        public Action<float> OnWeaponReloadStart = null;
        public Action OnWeaponReloadEnd = null;

        protected bool IsReloading = false;
        protected bool IsInShotCooldown = false;

        public void InitWeapon(WeaponDefinition definition)
        {
            Model = new WeaponModel();
            Model.Init(definition);
            View = GetComponent<WeaponView>();
            if (View == null)
                View = gameObject.AddComponent<WeaponView>();
        }

        public void HandleWeaponShootInput()
        {
            if (IsReloading || IsInShotCooldown) return;

            if (Model.HasEnoughAmmoToShoot)
                Shoot();
            else
            if (Model.HasEnoughAmmoToReload)
                StartReload();
            else
                View.HandleEmptyWeaponShoot();
        }

        public void HandleWeaponReloadInput()
        {
            if (IsReloading || Model.MagazineIsFull) return;

            StartReload();
        }

        protected void Shoot()
        {
            Model.HandleShootCost();
            View.HandleShootEffects();
            OnWeaponShot?.Invoke();
            IsInShotCooldown = true;
            Invoke(nameof(EndShootCooldown), Model.Definition.BaseShotCooldown);
        }

        protected virtual void EndShootCooldown()
        {
            IsInShotCooldown = false;
        }
        protected void StartReload()
        {
            IsReloading = true;
            View.HandleReloadStart();
            Invoke(nameof(EndReload), Model.Definition.BaseReloadDuration);
        }

        protected void EndReload()
        {
            View.HandleReloadEnd();
            Model.HandleReloadExchange();
            IsReloading = false;
            OnWeaponReloadEnd?.Invoke();
        }
    }
}