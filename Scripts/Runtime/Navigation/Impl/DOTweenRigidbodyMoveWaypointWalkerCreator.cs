using System.Collections.Generic;
using BestLostNFound;
using niscolas.OdinCompositeAttributes;
using niscolas.UnityExtensions;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace niscolas.UnityUtils.Extras
{
    public class DOTweenRigidbodyMoveWaypointWalkerCreator : WaypointWalkerCreator
    {
        [Title("Base Settings")]
        [FormerlySerializedAs("_baseWaypointWalkerSettings"), FormerlySerializedAs("_baseData")]
        [ExtractContent, SerializeField]
        private DOTweenRigidbodyMoveWaypointWalkerSettings _baseSettings;

        protected override void Inner_CreateNew(
            GameObject target, Vector3 initialPosition, List<Waypoint> waypoints)
        {
            target.GetOrAddComponent(out DOTweenRigidbodyMoveWaypointWalker waypointWalker);

            waypointWalker.Steps = new List<WaypointWalkerStep> {GetDefaultStep()};
            waypointWalker.Settings = _baseSettings;

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