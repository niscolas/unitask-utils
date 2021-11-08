using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    public abstract class DOTweenWaypointWalker<T> : WaypointWalker
        where T : DOTweenWaypointWalkerSettings
    {
        [SerializeField]
        protected T _settings;

        public T Settings
        {
            get => _settings;
            set => _settings = value;
        }

        private Tween _runningTween;

        protected abstract Tween GetWalkToTween(Vector3 targetPosition);

        protected override void OnDisable()
        {
            base.OnDisable();
            _runningTween.Kill();
        }

        public override UniTask WalkTo(Vector3 targetPosition)
        {
            _runningTween = GetWalkToTween(targetPosition)
                .SetSpeedBased(_settings.IsSpeedBased)
                .SetEase(_settings.FollowEase)
                .SetLink(_gameObject, _settings.LinkBehaviour);

            return _runningTween
                .AsyncWaitForCompletion()
                .AsUniTask();
        }
    }
}