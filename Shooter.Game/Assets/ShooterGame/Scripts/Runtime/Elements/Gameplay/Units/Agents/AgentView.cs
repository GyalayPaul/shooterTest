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
            var clip =
            AgentController.Definition.AttackSounds[Random.Range(0, AgentController.Definition.AttackSounds.Count)];
            AudioSource.Stop();
            AudioSource.clip = clip;
            AudioSource.loop = false;
            AudioSource.Play();
        }
    }
}