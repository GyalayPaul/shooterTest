using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class AgentPatrolComponent : MonoBehaviour
    {
        public List<Transform> PatrolWaypoints = new List<Transform>();
        public Transform CurrentTarget = null;
        protected int CurrentPatrolIndex = 0;

        public bool HasWaypoints => PatrolWaypoints.Count > 0;
        public void SetPatrol(List<Transform> waypoints)
        {
            ClearPatrol();
            if (waypoints.Count == 0)
            {
                Debug.LogError("Setting empty patrol!");
                return;
            }
            PatrolWaypoints = waypoints;
            CurrentTarget = PatrolWaypoints[0];
        }
        public void ClearPatrol()
        {
            CurrentPatrolIndex = 0;
            PatrolWaypoints.Clear();
        }
        public void MoveNextTarget()
        {
            CurrentPatrolIndex += 1;
            if (CurrentPatrolIndex >= PatrolWaypoints.Count)
                CurrentPatrolIndex = 0;
            CurrentTarget = PatrolWaypoints[CurrentPatrolIndex];
        }
        public Transform GetCurrentPatrolTarget()
        {
            if (CurrentPatrolIndex < PatrolWaypoints.Count)
                return PatrolWaypoints[CurrentPatrolIndex];
            else
                return null;
        }
    }
}