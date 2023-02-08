using DG.Tweening;
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
        public void Attack(UnitController target)
        {
            var damage = AgentModel.GetAttacKDamage();
            AgentView.HandleAttackEffects();
            damage.Apply(target);
        }

        public override void Die(Damage damageSource)
        {
            OnDeath?.Invoke(damageSource);
            StateMachine.enabled = false;
            NaveMeshAgent.enabled = false;
            AgentView.DoDeathSound();
            transform.DOScale(0, 1f).onComplete=() => { SelfDestruct(); }; //todo: move to view
        }

        public void SelfDestruct()
        {
            Destroy(gameObject);
        }
    }
}