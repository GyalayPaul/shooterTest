using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    /// <summary>
    /// Definition for units with behaviours that require movement, sight and attacking. 
    /// </summary>
    [CreateAssetMenu(fileName = "Agent", menuName = "ScriptableObjects/Units/Agent")]
    public class AgentDefinition : UnitDefinition
    {
        
        public float SightRange=10;
        public float AggroRange = 16;
        public float SightAngle=60;
        public int AttackDamage = 10;
        public float AttackRange = 2f;
        public DamageType DamageType = DamageType.Melee;
        public float AttackCooldown = 0.5f;

        public List<AudioClip> AttackSounds = new List<AudioClip>();
        public List<AudioClip> IdleSounds = new List<AudioClip>();
        public Vector2 IdleSoundsWaitRange = new Vector2(3, 10);
        public List<AudioClip> HuntSounds = new List<AudioClip>();
        public Vector2 HuntSoundsWaitRange = new Vector2(3, 6); 
        public List<AudioClip> HurtSounds = new List<AudioClip>();
        public List<AudioClip> DeathSounds = new List<AudioClip>();
    }
}