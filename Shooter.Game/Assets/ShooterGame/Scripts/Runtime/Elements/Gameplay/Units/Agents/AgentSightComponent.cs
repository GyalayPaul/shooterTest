using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    /// <summary>
    /// Component for agents which is responsible for determining detecting other units.
    /// </summary>
    public class AgentSightComponent : MonoBehaviour
    {
        public AgentController Agent;
        public AgentDefinition AgentDefinition => Agent.AgentModel.AgentDefinition;
        protected UnitManager UnitManager => Game.Instance.LevelManager.ActiveLevel.UnitManager;

        public void Init(AgentController agent)
        {
            Agent = agent;

        }
        public UnitController GetFirstVisibleEnemy()
        {
            var viableTargets = UnitUtils.GetUnitsInRange(transform.position, AgentDefinition.SightRange, Faction.Player);

            for (int i = 0; i < viableTargets.Count; i++)
            {
                if (TargetIsVisible(viableTargets[i].transform))
                {
                    return viableTargets[i];
                }
            }
            return null;
        }

        public bool TargetIsVisible(Transform target, bool ignoreLoS = false, float heightOffset = 1.2f)
        {
            if (ignoreLoS || UnitUtils.TargetIsWithinVisisonCone(target.transform, transform.forward, AgentDefinition.SightAngle, transform))
            {
                if (UnitUtils.HasClearRaycastToTarget(target.transform, AgentDefinition.SightRange, transform, heightOffset))
                {
                    return true;
                }
            }
            return false;
        }

        public bool TargetIsWithinAggroRange(Transform target)
        {
            var distance = Vector3.Distance(target.position, transform.position);
            return  distance < AgentDefinition.AggroRange;
        }

        public bool TargetIsWithinAttackRange(Transform target)
        {
            return Vector3.Distance(transform.position, target.position) <= AgentDefinition.AttackRange;
        }
    }
}