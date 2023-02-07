using Shooter.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.AI
{
    public class EnemyChaseState : AgentState
    {
        public EnemyAttackState attackState;
        public bool isInAttackRange;

        public override AgentState DoState(AgentStateMachine stateManager)
        {
            var behaviour = stateManager as EnemyStateMachine;
            // If the target dies or is null, return to patrolling. 
            if (behaviour.CurrentTarget == null)
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

            stateManager.Unit.NaveMeshAgent.isStopped = false;
            // Check if can see and attack unit.
            if (behaviour.Unit.SightComponent.TargetIsWithinAttackRange(target.transform))
            {
                if (behaviour.Unit.SightComponent.TargetIsVisible(target.transform))
                    return OnStateExit((stateManager as EnemyStateMachine).AttackState);
            }

            //Continue moving towards target's position. (Maybe update every x seconds for optimization later on?)
            stateManager.Unit.NaveMeshAgent.SetDestination((stateManager as EnemyStateMachine).CurrentTarget.transform.position);
            return this;
        }

        public override AgentState OnStateEnter(AgentState PreviousState, AgentStateMachine behaviour)
        {
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