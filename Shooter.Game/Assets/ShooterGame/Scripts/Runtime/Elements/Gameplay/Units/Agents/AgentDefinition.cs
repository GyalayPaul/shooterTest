using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
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


    }
}