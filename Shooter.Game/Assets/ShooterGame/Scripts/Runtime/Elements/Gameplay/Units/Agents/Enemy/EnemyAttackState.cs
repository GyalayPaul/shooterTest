using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.AI
{
    /// <summary>
    /// AI state where the enemies try to attack their target if it is visible and whithn attack range. If the target is no longer in the attack range they will go back to chase.
    /// </summary>
    public class EnemyAttackState : AgentState
    {
        public float AttackCooldown { get; protected set; }
        public override AgentState DoState(AgentStateMachine stateManager)
        {
            var behaviour = stateManager as EnemyStateMachine;

            // If target is dead or null, go back to patrol. 
            if (behaviour.CurrentTarget == null || behaviour.CurrentTarget.Model.Alive == false)
            {
                behaviour.CurrentTarget = null;
                return OnStateExit(behaviour.PatrolState);
            }
            var target = behaviour.CurrentTarget;

            // Look at target
            TurnTowardsTarget(behaviour.Unit.transform, target.transform);

            // Attack target if with cooldown if the target is in range and reachable
            if (behaviour.Unit.SightComponent.TargetIsWithinAttackRange(target.transform))
            {
                // Wait for cooldown.
                if (AttackCooldown > 0)
                {
                    AttackCooldown -= Time.deltaTime;
                    return this;
                }
                else
                // Check if clear to attack.
                {
                    if (behaviour.Unit.SightComponent.TargetIsVisible(target.transform))
                    {
                        stateManager.Unit.Attack(target);
                        AttackCooldown = stateManager.Unit.Definition.AttackCooldown;
                        return this;
                    }
                }
            }
            return OnStateExit(behaviour.ChaseState);
        }

        private void TurnTowardsTarget(Transform observer, Transform subject)
        {
            Vector3 direction = (subject.position - observer.position);
            direction.y = 0;
            observer.transform.rotation = Quaternion.LookRotation(direction);
        }

        public override AgentState OnStateEnter(AgentState PreviousState, AgentStateMachine behaviour)
        {


            if (behaviour.Unit.AgentView.Animator)
                behaviour.Unit.AgentView.Animator.SetFloat("Speed", 0, 0, Time.deltaTime);
            behaviour.Unit.NavMeshAgent.isStopped = true;
            Debug.Log("Entered Attack State!");
            return this;
        }

        public override AgentState OnStateExit(AgentState TargetState)
        {
            Debug.Log("Entering " + TargetState.GetType().Name);
            return TargetState;
        }
    }
}