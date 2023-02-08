using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.AI
{
    /// <summary>
    /// Generic State class for state machine.
    /// </summary>
    public abstract class AgentState
    {
        public abstract AgentState DoState(AgentStateMachine stateManager);
        public abstract AgentState OnStateEnter(AgentState PreviousState, AgentStateMachine behaviour);
        public abstract AgentState OnStateExit(AgentState TargetState);
    }
}