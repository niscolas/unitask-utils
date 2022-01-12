using System.Collections.Generic;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    public class PositionLimiter : MonoBehaviour
    {
        [SerializeField]
        private BoundsMonoBehaviour _boundsBehaviour;

        private readonly List<LimitPositionTarget> _targets = new();

        private Bounds Bounds => _boundsBehaviour.Bounds;

        private void Update()
        {
            LimitTargetsPosition();
        }

        public void AddTarget(LimitPositionTarget target)
        {
            _targets.AddIfNotContains(target);
        }

        public void RemoveTarget(LimitPositionTarget target)
        {
            _targets.SafeRemove(target);
        }

        private void LimitTargetsPosition()
        {
            _targets.SafeForEach(LimitTargetPosition);
        }

        private void LimitTargetPosition(LimitPositionTarget target)
        {
            Transform targetTransform = target.TargetTransform;
            Vector3 targetPosition = targetTransform.position;

            if (CheckInsideBounds(targetPosition))
            {
                return;
            }

            Vector3 closestValidPoint = Bounds.ClosestPoint(targetPosition);
            targetTransform.position = closestValidPoint;
        }

        private bool CheckInsideBounds(Vector3 testPosition)
        {
            bool result = Bounds.Contains(testPosition);
            return result;
        }

        public void UpdateData(BoundsMonoBehaviour boundsBehaviour)
        {
            _boundsBehaviour = boundsBehaviour;
        }
    }
}