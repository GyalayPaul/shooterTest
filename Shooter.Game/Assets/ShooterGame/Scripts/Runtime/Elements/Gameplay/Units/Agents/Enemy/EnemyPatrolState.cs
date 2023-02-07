using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.AI
{
    public class EnemyPatrolState : AgentState
    {
        public override AgentState DoState(AgentStateMachine stateManager)
        {
            var unit = stateManager.Unit;
            var behaviour = stateManager as EnemyStateMachine;
            var navmeshAgent = stateManager.Unit.NaveMeshAgent;

            // If there's nowhere to patrol go to idle.
            if (!unit.CanPatrol)
                 return OnStateExit(behaviour.IdleState);


            // Check for enemies while patroling.
            var validTarget = behaviour.Unit.SightComponent.GetFirstVisibleEnemy();
            if (validTarget != null)
            {
                behaviour.CurrentTarget = validTarget;
                return OnStateExit(behaviour.ChaseState);
            }

            stateManager.Unit.NaveMeshAgent.isStopped = false;
            // If reached a waypoint, move to the next one.
            if (navmeshAgent.remainingDistance < 0.25f)
            {
                unit.PatrolComponent.MoveNextTarget();
                navmeshAgent.SetDestination(unit.PatrolComponent.CurrentTarget.position);
            }
            return this;
        }

        public override AgentState OnStateEnter(AgentState PreviousState, AgentStateMachine behaviour)
        {
            var navmeshAgent = behaviour.Unit.NaveMeshAgent;
            navmeshAgent.isStopped = false;
            navmeshAgent.SetDestination(behaviour.Unit.PatrolComponent.CurrentTarget.position);
            Debug.Log("Entered Patrol State!");
            return this;
        }

        public override AgentState OnStateExit(AgentState TargetState)
        {
            Debug.Log("Entering " + TargetState.GetType().Name);
            return TargetState;
        }


    }
}