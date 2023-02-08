using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.AI
{
    /// <summary>
    /// State machine class for enemies in the game that handles patrolling, being idle, chasing the player and attacking. 
    /// </summary>
    public class EnemyStateMachine: AgentStateMachine
    {
        public string CurrentStateName = "";
        public EnemyIdleState IdleState = new EnemyIdleState();
        public EnemyPatrolState PatrolState = new EnemyPatrolState();
        public EnemyChaseState ChaseState = new EnemyChaseState();
        public EnemyAttackState AttackState = new EnemyAttackState();

        public UnitController CurrentTarget = null;

        public void OnEnable()
        {
            CurrentState = IdleState;
        }
    }
}