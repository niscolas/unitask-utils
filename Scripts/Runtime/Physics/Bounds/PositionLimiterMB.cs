using System.Collections.Generic;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Position Limiter")]
    public class PositionLimiterMB : CachedMB
    {
        [SerializeField]
        private BoundsMB _boundsBehaviour;

        private readonly List<LimitPositionTargetMB> _targets = new List<LimitPositionTargetMB>();

        private Bounds Bounds => _boundsBehaviour.Bounds;

        private void Update()
        {
            LimitTargetsPosition();
        }

        public void AddTarget(LimitPositionTargetMB target)
        {
            _targets.AddIfNotContains(target);
        }

        public void RemoveTarget(LimitPositionTargetMB target)
        {
            _targets.SafeRemove(target);
        }

        private void LimitTargetsPosition()
        {
            _targets.SafeForEach(LimitTargetPosition);
        }

        private void LimitTargetPosition(LimitPositionTargetMB target)
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

        public void UpdateData(BoundsMB boundsBehaviour)
        {
            _boundsBehaviour = boundsBehaviour;
        }
    }
}