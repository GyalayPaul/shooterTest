using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.AI
{
    public abstract class AgentState
    {
        public abstract AgentState DoState(AgentStateMachine stateManager);

        public abstract AgentState OnStateEnter(AgentState PreviousState, AgentStateMachine behaviour);
        public abstract AgentState OnStateExit(AgentState TargetState);
    }
}