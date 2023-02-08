using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    /// <summary>
    /// View class for weapons. Handles visuals and effects such as partile effects, animations, sounds etc. for weapons. 
    /// </summary>
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
            if (Controller.Model.Definition.ShootSounds.Count < 1 || AudioSource == null) return;

            AudioUtils.PlayRandomizedOneshotSound(AudioSource, Controller.Model.Definition.ShootSounds);
        }

        public void HandleReloadStart()
        {
            if (Controller.Model.Definition.ReloadSounds.Count < 1 || AudioSource == null) return;
            AudioUtils.PlayRandomizedOneshotSound(AudioSource, Controller.Model.Definition.ReloadSounds);
        }

        public void HandleReloadEnd()
        {
            if (Controller.Model.Definition.ReloadEndSounds.Count < 1 || AudioSource == null) return;
            AudioUtils.PlayRandomizedOneshotSound(AudioSource, Controller.Model.Definition.ReloadEndSounds);
        }

        public void HandleEmptyWeaponShoot()
        {
            if (Controller.Model.Definition.EmptyWeaponShootSounds.Count < 1 || AudioSource == null) return;
            AudioUtils.PlayRandomizedOneshotSound(AudioSource, Controller.Model.Definition.EmptyWeaponShootSounds);
        }

    }
}
