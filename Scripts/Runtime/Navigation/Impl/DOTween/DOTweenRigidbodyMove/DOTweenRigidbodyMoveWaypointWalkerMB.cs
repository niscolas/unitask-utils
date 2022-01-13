using DG.Tweening;
using niscolas.UnityUtils.Core;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    public class DOTweenRigidbodyMoveWaypointWalkerMB :
        DOTweenWaypointWalkerMB<DOTweenRigidbodyMoveWaypointWalkerSettings>
    {
        [SerializeField]
        private Rigidbody _rigidbody;

        protected override void Start()
        {
            gameObject.IfUnityNullGetComponentFromRoot(ref _rigidbody);
            base.Start();
        }

        public override void WalkToInstant(Vector3 targetPosition)
        {
            _rigidbody.position = targetPosition;
        }

        protected override Tween GetWalkToTween(Vector3 targetPosition)
        {
            return _rigidbody.DOMove(
                targetPosition, _settings.ComputeRealDuration());
        }
    }
}