using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class WeaponView : MonoBehaviour
    {
        public WeaponController Controller;
        public AudioSource AudioSource;

        public void Awake()
        {
            if (AudioSource == null) AudioSource = GetComponent<AudioSource>();
            if (AudioSource == null) Debug.LogError("WeaponView: Couldn't find audiosource!");
        }
        public void HandleShootEffects()
        {

            if (Controller.Model.Definition.ShootSounds.Count < 1 || AudioSource== null) return;
            AudioSource.Stop();
            AudioSource.loop = false;
            AudioSource.clip = Controller.Model.Definition.ShootSounds[Random.Range(0, Controller.Model.Definition.ShootSounds.Count)];
            AudioSource.Play();
        }

        public void HandleReloadStart()
        {
            if (Controller.Model.Definition.ReloadSounds.Count < 1 || AudioSource == null) return;
            AudioSource.Stop();
            AudioSource.loop = false;
            AudioSource.clip = Controller.Model.Definition.ReloadSounds[Random.Range(0, Controller.Model.Definition.ReloadSounds.Count)];
            AudioSource.Play();
        }

        public void HandleReloadEnd()
        {
            if (Controller.Model.Definition.ReloadEndSounds.Count < 1 || AudioSource == null) return;
            AudioSource.Stop();
            AudioSource.loop = false;
            AudioSource.clip = Controller.Model.Definition.ReloadEndSounds[Random.Range(0, Controller.Model.Definition.ReloadEndSounds.Count)];
            AudioSource.Play();
        }

        public void HandleEmptyWeaponShoot()
        {
            if (Controller.Model.Definition.EmptyWeaponShootSounds.Count < 1 || AudioSource == null) return;

            AudioSource.Stop();
            AudioSource.loop = false;
            AudioSource.clip = Controller.Model.Definition.EmptyWeaponShootSounds[Random.Range(0, Controller.Model.Definition.EmptyWeaponShootSounds.Count)];
            AudioSource.Play();
        }
    }
}