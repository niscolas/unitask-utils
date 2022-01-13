using System.Collections.Generic;
using niscolas.OdinCompositeAttributes;
using niscolas.UnityUtils.Core.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "DOTween" + NiceClassSuffix)]
    public class DOTweenWaypointWalkerCreatorMonoBehaviour<TWalker, TSettings> : WaypointWalkerCreatorMonoBehaviour
        where TWalker : DOTweenWaypointWalkerMB<TSettings>
        where TSettings : DOTweenWaypointWalkerSettings
    {
        [Title("Base Settings")]
        [ExtractContent]
        [SerializeField]
        private TSettings _baseSettings;

        protected override void Inner_Create(
            GameObject target, Vector3 initialPosition, List<Waypoint> waypoints)
        {
            target.GetOrAddComponent(out TWalker waypointWalker);

            waypointWalker.Steps = new List<WaypointWalkerStep> {GetDefaultStep(waypoints)};
            waypointWalker.Settings = _baseSettings;

            target.GetOrAddComponent(out ColliderCallbacksMB colliderDisableCallbacks);

            void OnColliderDisabled()
            {
                Remove(target);
                colliderDisableCallbacks.Disabled -= OnColliderDisabled;
            }

            colliderDisableCallbacks.Disabled += OnColliderDisabled;
        }
    }
}