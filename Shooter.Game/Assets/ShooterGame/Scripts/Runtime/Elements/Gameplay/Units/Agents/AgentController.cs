using Shooter.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Shooter
{
    public class AgentController : UnitController
    {
        public AgentModel AgentModel => Model as AgentModel;
        public AgentView AgentView => View as AgentView;
        public AgentDefinition Definition => AgentModel.AgentDefinition;
        public NavMeshAgent NaveMeshAgent;
        public AgentStateMachine StateMachine;
        public AgentPatrolComponent PatrolComponent;
        public AgentSightComponent SightComponent;
        public bool CanPatrol => PatrolComponent.HasWaypoints;
        public override void Init(UnitDefinition definition)
        {
            Model = new AgentModel(definition as AgentDefinition, this);
            Model.OnDeath += Die;
            View.Controller = this;
            PatrolComponent = gameObject.AddComponent<AgentPatrolComponent>();
            SightComponent = gameObject.AddComponent<AgentSightComponent>();
            SightComponent.Init(this);
        }
        public void Attack(UnitController Target)
        {
            var damage = AgentModel.GetAttacKDamage();
            AgentView.HandleAttackEffects();
            Target.ApplyDamage(damage);
        }
    }
}