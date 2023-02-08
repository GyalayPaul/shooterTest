using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.AI
{
    public class EnemyPatrolState : AgentState
    {
        public float IdleBarkCooldown = 5f;
        public override AgentState DoState(AgentStateMachine stateManager)
        {
            var unit = stateManager.Unit;
            var behaviour = stateManager as EnemyStateMachine;
            var navmeshAgent = stateManager.Unit.NaveMeshAgent;

            // If there's nowhere to patrol go to idle.
            if (!unit.CanPatrol)
                return OnStateExit(behaviour.IdleState);

            //Bark Timer
            if (IdleBarkCooldown <= 0)
            {
                unit.AgentView.DoIdleBark();
                IdleBarkCooldown = Random.Range(behaviour.Unit.Definition.IdleSoundsWaitRange.x, behaviour.Unit.Definition.IdleSoundsWaitRange.y);
            }
            else
                IdleBarkCooldown -= Time.deltaTime;

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

                if (behaviour.Unit.AgentView.Animator)
                    unit.AgentView.Animator.SetFloat("Speed", 1, 0, Time.deltaTime);
                navmeshAgent.SetDestination(unit.PatrolComponent.CurrentTarget.position);

            }
            return this;
        }

        public override AgentState OnStateEnter(AgentState PreviousState, AgentStateMachine behaviour)
        {
            var navmeshAgent = behaviour.Unit.NaveMeshAgent;
            navmeshAgent.isStopped = false;
            navmeshAgent.SetDestination(behaviour.Unit.PatrolComponent.CurrentTarget.position);

            if (behaviour.Unit.AgentView.Animator)
                behaviour.Unit.AgentView.Animator.SetFloat("Speed", 1, 0, Time.deltaTime);
            IdleBarkCooldown = Random.Range(behaviour.Unit.Definition.IdleSoundsWaitRange.x / 2, behaviour.Unit.Definition.IdleSoundsWaitRange.y / 2);
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