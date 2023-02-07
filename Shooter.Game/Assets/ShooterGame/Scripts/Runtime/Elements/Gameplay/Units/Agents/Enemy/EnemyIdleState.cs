using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shooter.AI
{
    public class EnemyIdleState : AgentState
    {
        public override AgentState DoState(AgentStateMachine stateManager)
        {
            var behaviour = stateManager as EnemyStateMachine;

            // If has a patrol set, move to patrol state.
            if (behaviour.Unit.CanPatrol)
                return OnStateExit(behaviour.PatrolState);

            // Look for enemies to chase/attack.
            var validTarget = behaviour.Unit.SightComponent.GetFirstVisibleEnemy();
            if (validTarget != null)
            {
                behaviour.CurrentTarget = validTarget;
                return OnStateExit(behaviour.ChaseState);
            }
            else
                return this;
        }

        public override AgentState OnStateEnter(AgentState PreviousState, AgentStateMachine behaviour)
        {
            Debug.Log("Entered Idle State!");
            return this;
        }

        public override AgentState OnStateExit(AgentState TargetState)
        {

            Debug.Log("Entering " + TargetState.GetType().Name);
            return TargetState;
        }
    }
}