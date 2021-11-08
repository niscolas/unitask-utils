using System.Collections.Generic;
using BestLostNFound;
using niscolas.OdinCompositeAttributes;
using niscolas.UnityExtensions;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace niscolas.UnityUtils.Extras
{
    public class DOTweenWaypointWalkerCreator<TWalker, TSettings> : WaypointWalkerCreator
        where TWalker : DOTweenWaypointWalker<TSettings>
        where TSettings : DOTweenWaypointWalkerSettings
    {
        [Title("Base Settings")]
        [ExtractContent, SerializeField]
        private TSettings _baseSettings;

        protected override void Inner_Create(
            GameObject target, Vector3 initialPosition, List<Waypoint> waypoints)
        {
            target.GetOrAddComponent(out TWalker waypointWalker);

            waypointWalker.Steps = new List<WaypointWalkerStep> {GetDefaultStep(waypoints)};
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