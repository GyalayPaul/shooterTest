using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
    public class WeaponDefinition : ScriptableObject
    {
        public int BaseMagazineAmmoCapacity = 6;
        public int BaseMaxStoredAmmoCapacity = 0;
        public float BaseReloadDuration = 2;
        public float BaseShotCooldown = 0.25f;
        public int BaseDamage = 5;
        public int BaseAmmoPerShot = 1;
        public WeaponController ModelPrefab; 
    }
}