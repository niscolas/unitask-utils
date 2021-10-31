using System.Collections.Generic;
using BestLostNFound;
using niscolas.UnityExtensions;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    public class DOTweenRigidbodyMoveWaypointWalkerCreator : WaypointWalkerCreator
    {
        [SerializeField]
        private DOTweenRigidbodyMoveData _baseData;

        protected override void Inner_CreateNew(
            GameObject target, Vector3 initialPosition, List<Waypoint> waypoints)
        {
            target.GetOrAddComponent(out DOTweenRigidbodyMoveWaypointWalker waypointWalker);

            WaypointWalkerStep step = new WaypointWalkerStep
            {
                Waypoints = waypoints,
                PlayTimes = -1,
                StartFromFirstWaypoint = false
            };

            waypointWalker.Steps = new List<WaypointWalkerStep> {step};
            waypointWalker.Data = _baseData;

            target.GetOrAddComponent(out ColliderCallbacks colliderDisableCallbacks);

            void OnColliderDisabled()
            {
                Remove(target);
                colliderDisableCallbacks.Disabled -= OnColliderDisabled;
            }

            colliderDisableCallbacks.Disabled += OnColliderDisabled;
        }
    }
}