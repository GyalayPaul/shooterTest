using Shooter.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.AI
{
    /// <summary>
    /// AI state for enemies where they chase a target until they are within attack range. When they are they will go into attack state, or if the target is too far away they go back in the patrol state.
    /// </summary>
    public class EnemyChaseState : AgentState
    {
        public EnemyAttackState attackState;
        public bool isInAttackRange;
        public float HuntBarkTimer = 5f;

        public override AgentState DoState(AgentStateMachine stateManager)
        {
            var behaviour = stateManager as EnemyStateMachine;
            // If the target dies or is null, return to patrolling. 
            if (behaviour.CurrentTarget == null || behaviour.CurrentTarget.Model.Alive == false)
            {
                return OnStateExit((stateManager as EnemyStateMachine).PatrolState);
            }
            var target = behaviour.CurrentTarget;

            // If unit is outside aggro range, go back to patrol or idle. 
            if (!behaviour.Unit.SightComponent.TargetIsWithinAggroRange(target.transform))
            {
                behaviour.CurrentTarget = null;
                return OnStateExit((stateManager as EnemyStateMachine).PatrolState);
            }
            // Do Bark timer
            if (HuntBarkTimer <= 0)
            {
                stateManager.Unit.AgentView.DoHuntBark();
                HuntBarkTimer = Random.Range(behaviour.Unit.Definition.HuntSoundsWaitRange.x, behaviour.Unit.Definition.HuntSoundsWaitRange.y);
            }
            else
                HuntBarkTimer -= Time.deltaTime;

            stateManager.Unit.NavMeshAgent.isStopped = false;
            // Check if can see and attack unit.
            if (behaviour.Unit.SightComponent.TargetIsWithinAttackRange(target.transform))
            {
                if (behaviour.Unit.SightComponent.TargetIsVisible(target.transform))
                    return OnStateExit((stateManager as EnemyStateMachine).AttackState);
            }

            //Continue moving towards target's position. (Maybe update every x seconds for optimization later on?)
            stateManager.Unit.NavMeshAgent.SetDestination((stateManager as EnemyStateMachine).CurrentTarget.transform.position);
            return this;
        }

        public override AgentState OnStateEnter(AgentState PreviousState, AgentStateMachine behaviour)
        {

            if (behaviour.Unit.AgentView.Animator)
                behaviour.Unit.AgentView.Animator.SetFloat("Speed", 1, 0, Time.deltaTime);
            HuntBarkTimer =  Random.Range(behaviour.Unit.Definition.HuntSoundsWaitRange.x/2, behaviour.Unit.Definition.HuntSoundsWaitRange.y/2);
            Debug.Log("Entered Chase State!");
            return this;
        }

        public override AgentState OnStateExit(AgentState TargetState)
        {
            Debug.Log("Entering " + TargetState.GetType().Name);
            return TargetState;
        }

    }
}