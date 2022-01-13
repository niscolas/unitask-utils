using System.Collections.Generic;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Extras
{
    public abstract class WaypointWalkerCreatorMonoBehaviour : SerializedMonoBehaviour
    {
        [SerializeField]
        private List<Waypoint> _waypoints;

        [SerializeField]
        protected BoolReference _startFromFirstWaypoint = new(false);

        [SerializeField]
        protected IntReference _playTimes;

        [Title(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent<GameObject> _onBeforeCreated;

        [SerializeField]
        private UnityEvent<GameObject> _onAfterCreated;

        [SerializeField]
        private UnityEvent<GameObject> _onDestroyed;

        [SerializeField]
        private UnityEvent _onWaypointReached;

        [SerializeField]
        private UnityEvent _onLoopCompleted;

        [SerializeField]
        private UnityEvent _onCompleted;

        [PropertyOrder(100)]
        [Title(HeaderTitles.Debug)]
        [ColorUsage(true, true)]
        [SerializeField]
        private Color _pathGizmosColor;

        protected const string NiceClassSuffix = "Waypoint Walker Creator";

        private static readonly IDespawnService DespawnService = new UnityDestroyService();

        private void OnDrawGizmos()
        {
            DrawConveyorPathGizmos();
        }

        protected abstract void Inner_Create(
            GameObject target, Vector3 initialPosition, List<Waypoint> waypoints);

        public void Create(GameObject target)
        {
            GetWaypointWalkerCreationData(
                target,
                out Vector3 nearestInitialPosition,
                out int nearestWaypointIndex);

            _onBeforeCreated?.Invoke(target);

            Inner_Create(
                target,
                nearestInitialPosition,
                ComputeWaypointWalkerWaypoints(nearestWaypointIndex));

            _onAfterCreated?.Invoke(target);
        }

        private void GetWaypointWalkerCreationData(
            GameObject target,
            out Vector3 initialPosition,
            out int nearestWaypointIndex)
        {
            nearestWaypointIndex = default;
            float nearestWaypointLineDistance = float.PositiveInfinity;
            initialPosition = default;

            Vector3 targetPosition = target.transform.position;

            for (int i = 0; i < _waypoints.Count; i++)
            {
                Vector3 currentWaypointPosition = _waypoints[i].Position;
                int nextWaypointIndex = (i + 1) % _waypoints.Count;
                Vector3 nextWaypointPosition = _waypoints[nextWaypointIndex].Position;

                Vector3 currentNearestLinePosition = targetPosition.NearestPositionOnLine(
                    currentWaypointPosition, nextWaypointPosition);

                float currentNearestLineDistance = Vector3.Distance(
                    targetPosition, currentNearestLinePosition);

                if (currentNearestLineDistance >= nearestWaypointLineDistance)
                {
                    continue;
                }

                nearestWaypointIndex = i;
                nearestWaypointLineDistance = currentNearestLineDistance;
                initialPosition = currentNearestLinePosition;
            }
        }

        public void Remove(GameObject target)
        {
            if (!target.TryGetComponent(out WaypointWalkerMB waypointWalker))
            {
                return;
            }

            DespawnService.Despawn(waypointWalker);
            _onDestroyed?.Invoke(target);
        }

        private List<Waypoint> ComputeWaypointWalkerWaypoints(int index)
        {
            List<Waypoint> waypointWalkerWaypoints = new();

            for (int i = 1; i <= _waypoints.Count; i++)
            {
                int waypointIndex = (i + index) % _waypoints.Count;
                waypointWalkerWaypoints.Add(_waypoints[waypointIndex]);
            }

            return waypointWalkerWaypoints;
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

        protected WaypointWalkerStep GetDefaultStep(List<Waypoint> waypoints)
        {
            return new WaypointWalkerStep
            {
                Waypoints = waypoints,
                PlayTimes = _playTimes.Value,
                StartFromFirstWaypoint = _startFromFirstWaypoint.Value,
                OnWaypointReached = _onWaypointReached,
                OnLoopCompleted = _onLoopCompleted,
                OnCompleted = _onCompleted
            };
        }
    }
}