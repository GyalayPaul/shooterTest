using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.AI
{
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
            //CurrentState.OnStateExit(nextState);
            if (nextState != CurrentState)
            {
                nextState?.OnStateEnter(CurrentState, this);
                CurrentState = nextState;
            }
            
        }
    }
}