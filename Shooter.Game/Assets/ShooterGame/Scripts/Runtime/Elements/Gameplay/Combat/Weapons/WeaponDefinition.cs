using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    /// <summary>
    /// Definition class for weapons containing base stats for the weapon and sounds. 
    /// </summary>
    [CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
    public class WeaponDefinition : ScriptableObject
    {
        public int BaseMagazineAmmoCapacity = 6;
        public int BaseMaxStoredAmmoCapacity = 0;
        public float BaseReloadDuration = 2;
        public float BaseShotCooldown = 0.25f;
        public int BaseDamage = 5;
        public DamageType DamageType = DamageType.Ranged;
        public int BaseAmmoPerShot = 1;
        public float MaxRange = 25;
        public WeaponController ModelPrefab;

        public List<AudioClip> ShootSounds;
        public List<AudioClip> ReloadSounds;
        public List<AudioClip> ReloadEndSounds;
        public List<AudioClip> EmptyWeaponShootSounds;
    }
}