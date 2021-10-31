using System;
using System.Collections.Generic;
using niscolas.UnityExtensions;
using niscolas.UnityUtils.Extras;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BestLostNFound
{
    public abstract class WaypointWalkerCreator : SerializedMonoBehaviour
    {
        [SerializeField]
        private List<Waypoint> _waypoints;

        [Title("Debug")]
        [ColorUsage(true, true), SerializeField]
        private Color _pathGizmosColor;

        protected abstract void Inner_CreateNew(
            GameObject target, Vector3 initialPosition, List<Waypoint> waypoints);

        public void CreateNew(GameObject target)
        {
            int nearestWaypointLineIndex = default;
            float nearestWaypointLineDistance = float.PositiveInfinity;
            Vector3 nearestInitialPosition = default;

            Vector3 targetPosition = target.transform.position;

            for (int i = 0; i < _waypoints.Count; i++)
            {
                Vector3 currentWaypointPosition = _waypoints[i].Position;
                Vector3 nextWaypointPosition = _waypoints[(i + 1) % _waypoints.Count].Position;

                Vector3 currentNearestLinePosition = targetPosition.NearestPositionOnLine(
                    currentWaypointPosition, nextWaypointPosition);

                float currentNearestLineDistance = Vector3.Distance(
                    targetPosition, currentNearestLinePosition);

                if (currentNearestLineDistance < nearestWaypointLineDistance)
                {
                    nearestWaypointLineIndex = i;
                    nearestWaypointLineDistance = currentNearestLineDistance;
                    nearestInitialPosition = currentNearestLinePosition;
                }
            }

            Inner_CreateNew(
                target,
                nearestInitialPosition,
                ComputeWaypointWalkerWaypoints(nearestWaypointLineIndex));
        }

        public void Remove(GameObject target)
        {
            if (!target.TryGetComponent(out WaypointWalker waypointWalker))
            {
                return;
            }
            
            Destroy(waypointWalker);
        }

        private List<Waypoint> ComputeWaypointWalkerWaypoints(int index)
        {
            List<Waypoint> waypointWalkerWaypoints = new List<Waypoint>();

            for (int i = 1; i <= _waypoints.Count; i++)
            {
                int waypointIndex = (i + index) % _waypoints.Count;
                waypointWalkerWaypoints.Add(_waypoints[waypointIndex]);
            }

            return waypointWalkerWaypoints;
        }

        private void OnDrawGizmos()
        {
            DrawConveyorPathGizmos();
        }

        private void DrawConveyorPathGizmos()
        {
            Gizmos.color = _pathGizmosColor;

            int waypointsCount = _waypoints.Count;

            for (int i = 0; i < waypointsCount; i++)
            {
                Gizmos.DrawLine(
                    _waypoints[i].Position,
                    _waypoints[(i + 1) % waypointsCount].Position);
            }
        }
    }
}