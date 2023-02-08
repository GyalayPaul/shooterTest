using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    /// <summary>
    /// Controller class for weapons, handles input, shooting, reloading and weapon initialization.
    /// </summary>
    public class WeaponController : MonoBehaviour
    {
        public UnitController Wielder;
        public WeaponModel Model { get; protected set; }
        public WeaponView View;

        public Action OnWeaponShot = null;
        public Action<float> OnWeaponReloadStart = null;
        public Action OnWeaponReloadEnd = null;

        protected bool IsReloading = false;
        protected bool IsInShotCooldown = false;

        public void InitWeapon(WeaponDefinition definition, UnitController wielder)
        {
            Model = new WeaponModel(this, definition);
            Wielder = wielder;
            View = GetComponent<WeaponView>();
            if (View == null)
                View = gameObject.AddComponent<WeaponView>();
            View.Controller = this;
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
            DoRaycastShot();
            OnWeaponShot?.Invoke();
            IsInShotCooldown = true;
            Invoke(nameof(EndShootCooldown), Model.Definition.BaseShotCooldown);
        }

        protected void DoRaycastShot()
        {
            var Damage = Model.GetDamage();
            var WeaponRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(WeaponRay, out hit, Model.Definition.MaxRange))
            {
                var unitController = hit.transform.gameObject.GetComponent<UnitController>();
                if (unitController)
                {
                    Damage.Apply(unitController);
                }
            }
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