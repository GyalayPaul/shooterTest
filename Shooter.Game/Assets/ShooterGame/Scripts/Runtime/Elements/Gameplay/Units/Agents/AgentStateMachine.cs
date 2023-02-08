using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.AI
{
    /// <summary>
    /// Generic state machine template.
    /// </summary>
    public class AgentStateMachine : MonoBehaviour
    {
        public virtual AgentState CurrentState { get; protected set; }
        public AgentController Unit;

        void FixedUpdate()
        {
            RunStateMachine();
        }
        protected virtual void RunStateMachine()
        {
            AgentState nextState = CurrentState?.DoState(this);

            if (nextState != null)
            {
                DoStateTransition(nextState);
            }
        }

        protected virtual void DoStateTransition(AgentState nextState)
        {
            if (nextState != CurrentState)
            {
                CurrentState.OnStateExit(nextState);
                nextState?.OnStateEnter(CurrentState, this);
                CurrentState = nextState;
            }
            
        }
    }
}