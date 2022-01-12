using DG.Tweening;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    public class DoTweenTransformMoveWaypointWalkerMonoBehaviour :
        DOTweenWaypointWalkerMonoBehaviour<DOTweenTransformMoveWaypointWalkerSettings>
    {
        [SerializeField]
        private Transform _target;

        private Transform Target
        {
            get
            {
                if (!_target)
                {
                    _target = transform;
                }

                return _target;
            }
        }

        public override void WalkToInstant(Vector3 targetPosition)
        {
            Target.position = targetPosition;
        }

        protected override Tween GetWalkToTween(Vector3 targetPosition)
        {
            return Target.DOMove(
                targetPosition, _settings.ComputeRealDuration());
        }
    }
}