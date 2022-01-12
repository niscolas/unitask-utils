using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "DOTween Rigidbody" + NiceClassSuffix)]
    public class DOTweenRigidbodyMoveWaypointWalkerCreatorMonoBehaviour :
        DOTweenWaypointWalkerCreatorMonoBehaviour<
            DoTweenRigidbodyMoveWaypointWalkerMonoBehaviour, DOTweenRigidbodyMoveWaypointWalkerSettings> { }
}