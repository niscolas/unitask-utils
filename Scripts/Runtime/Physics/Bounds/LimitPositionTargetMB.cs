using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.UnityAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Limit Position Target")]
    public class LimitPositionTargetMB : CachedMB
    {
        [SerializeField]
        private Transform _targetTransform;

        [SerializeField]
        private ReferenceOrTag<PositionLimiterMB> _limiter;

        public Transform TargetTransform => _targetTransform;

        public PositionLimiterMB Limiter
        {
            get => _limiter.Value;
            set => _limiter.Value = value;
        }

        protected override void Awake()
        {
            base.Awake();
            UpdateTargetTransform();
        }

        private void Start()
        {
            SubscribeToLimiter();
        }

        private void OnDestroy()
        {
            if (!_limiter.Value)
            {
                return;
            }

            _limiter.Value.RemoveTarget(this);
        }

        private void UpdateTargetTransform()
        {
            if (!_targetTransform)
            {
                _targetTransform = transform;
            }
        }

        private void SubscribeToLimiter()
        {
            if (!_limiter.Value)
            {
                return;
            }

            _limiter.Value.AddTarget(this);
        }
    }
}