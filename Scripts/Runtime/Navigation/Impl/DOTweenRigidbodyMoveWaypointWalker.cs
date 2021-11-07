using Cysharp.Threading.Tasks;
using DG.Tweening;
using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace niscolas.UnityUtils.Extras
{
    public class DOTweenRigidbodyMoveWaypointWalker : WaypointWalker
    {
        [SerializeField]
        private Rigidbody _rigidbody;

        [SerializeField]
        private DOTweenRigidbodyMoveWaypointWalkerSettings _settings;

        public DOTweenRigidbodyMoveWaypointWalkerSettings Settings
        {
            get => _settings;
            set => _settings = value;
        }

        private Tween _runningTween;

        protected override void Start()
        {
            gameObject.IfUnityNullGetComponentFromRoot(ref _rigidbody);
            base.Start();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _runningTween.Kill();
        }

        public override void WalkToInstant(Vector3 targetPosition)
        {
            _rigidbody.position = targetPosition;
        }

        public override UniTask WalkTo(Vector3 targetPosition)
        {
            _runningTween = _rigidbody
                .DOMove(targetPosition, _settings.ComputeRealDuration())
                .SetSpeedBased(_settings.IsSpeedBased)
                .SetEase(_settings.FollowEase)
                .SetLink(_gameObject, LinkBehaviour.KillOnDisable);

            return _runningTween
                .AsyncWaitForCompletion()
                .AsUniTask();
        }
    }
}