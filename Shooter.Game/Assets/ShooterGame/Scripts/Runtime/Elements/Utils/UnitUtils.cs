using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public static class UnitUtils
    {

        public static bool TargetIsWithinVisisonCone(Transform target, Vector3 lookDirection, float coneAngle, Transform looker)
        {
            var direction = target.transform.position - looker.position;
            var angle = Vector3.Angle(direction, lookDirection);
            return (Mathf.Abs(angle) < coneAngle);
        }

        public static bool HasClearRaycastToTarget(Transform target, float maxRange, Transform looker, float yOffset = 1.2f)
        {
            var viewerLookPosition = looker.position + (Vector3.up * yOffset);
            var targetLookPosition = target.position + (Vector3.up * yOffset);
            var ray = new Ray(viewerLookPosition, targetLookPosition - viewerLookPosition);

            Debug.DrawLine(viewerLookPosition, targetLookPosition, Color.red);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, maxRange))
            {
                if (hitInfo.collider.gameObject == target.gameObject)
                    return true;
            }
            return false;
        }

    }
}