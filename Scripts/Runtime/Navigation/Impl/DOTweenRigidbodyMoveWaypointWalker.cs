using Cysharp.Threading.Tasks;
using DG.Tweening;
using niscolas.UnityUtils.Core;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    public class DOTweenRigidbodyMoveWaypointWalker : WaypointWalker
    {
        [SerializeField]
        private Rigidbody _rigidbody;

        [SerializeField]
        private DOTweenRigidbodyMoveData _data;

        public DOTweenRigidbodyMoveData Data
        {
            get => _data;
            set => _data = value;
        }

        private Tween _runningTween;

        protected override void Start()
        {
            _rigidbody = gameObject.IfNullGetComponentFromRoot(_rigidbody);
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
                .DOMove(targetPosition, _data.ComputeRealDuration())
                .SetSpeedBased(_data.IsSpeedBased)
                .SetEase(_data.FollowEase)
                .SetLink(_gameObject, LinkBehaviour.KillOnDisable);

            return _runningTween
                .AsyncWaitForCompletion()
                .AsUniTask();
        }
    }
}