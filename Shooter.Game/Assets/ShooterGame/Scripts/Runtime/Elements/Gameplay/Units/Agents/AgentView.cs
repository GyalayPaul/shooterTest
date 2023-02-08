using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Shooter
{
    /// <summary>
    /// View class for agents, contains functions to handle attacks, barks and death effects.
    /// </summary>
    public class AgentView : UnitView
    {
        public AgentController AgentController => Controller as AgentController;
        public void Awake()
        {

            Animator = GetComponent<Animator>();
        }
        public void HandleAttackEffects()
        {
            if (Animator)
                Animator?.SetTrigger("Attack");
            AudioUtils.PlayRandomizedOneshotSound(AudioSource,AgentController.Definition.AttackSounds);

        }

        public void DoIdleBark()
        {
            AudioUtils.PlayRandomizedOneshotSound(AudioSource, AgentController.Definition.IdleSounds);
        }

        public void DoHuntBark()
        {
            AudioUtils.PlayRandomizedOneshotSound(AudioSource, AgentController.Definition.HuntSounds);
        }

        public void DoHurtSound()
        {
            AudioUtils.PlayRandomizedOneshotSound(AudioSource, AgentController.Definition.HurtSounds);
        }

        public void DoDeathEffects()
        {
            if (Animator)
                Animator.SetTrigger("Dead");
            AudioUtils.PlayRandomizedOneshotSound(AudioSource, AgentController.Definition.DeathSounds);
        }
       
    }
}