using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "DOTween Transform" + NiceClassSuffix)]
    public class DOTweenTransformMoveWaypointWalkerCreatorMonoBehaviour :
        DOTweenWaypointWalkerCreatorMonoBehaviour<
            DOTweenTransformMoveWaypointWalkerMB, DOTweenTransformMoveWaypointWalkerSettings> { }
}