using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Shooter
{
    public class AgentView : UnitView
    {
        public AgentController AgentController => Controller as AgentController;
        public void HandleAttackEffects()
        {
            PlayRandomizedOneshotSound(AgentController.Definition.AttackSounds);
        }

        public void DoIdleBark()
        {
            PlayRandomizedOneshotSound(AgentController.Definition.IdleSounds);
        }

        public void DoHuntBark()
        {
            PlayRandomizedOneshotSound(AgentController.Definition.HuntSounds);
        }

        public void DoHurtSound()
        {
            PlayRandomizedOneshotSound(AgentController.Definition.HurtSounds);
        }

        public void DoDeathSound()
        {
            PlayRandomizedOneshotSound(AgentController.Definition.DeathSounds);
        }
        private void PlayRandomizedOneshotSound(List<AudioClip> clips, float volume= 1, float pitchvariation = 0.05f)
        {
            if (clips.Count <= 0) return;
            var clip = clips[Random.Range(0, clips.Count)];
            AudioSource.Stop();
            AudioSource.volume = volume;
            AudioSource.clip = clip;
            AudioSource.loop = false;
            AudioSource.pitch = 1 + Random.Range(-pitchvariation, pitchvariation);
            AudioSource.Play();
        }
    }
}