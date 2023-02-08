using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Shooter
{
    /// <summary>
    /// Model class for agents. 
    /// </summary>
    public class AgentModel : UnitModel
    {
        public AgentDefinition AgentDefinition => Definition as AgentDefinition;
        public AgentModel(AgentDefinition definition, AgentController controller) : base(definition, controller)
        {
            Definition = definition;
            Controller = controller;
            Health = new Stat(definition.BaseMaxHealth, definition.BaseStartingHealth);
            Health.OnMinValueReached += Die;
        }

        public Damage GetAttacKDamage()
        {
            return new Damage(AgentDefinition.AttackDamage, Controller, AgentDefinition.DamageType);
        }
        public override void ApplyDamage(Damage damage)
        {
            (Controller as AgentController).AgentView.DoHurtSound();
            base.ApplyDamage(damage);
        }
    }
}