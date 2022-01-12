using Cysharp.Threading.Tasks;
using DG.Tweening;
using niscolas.UnityUtils.Core;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    public abstract class DOTweenWaypointWalkerMonoBehaviour<T> : WaypointWalkerMonoBehaviour
        where T : DOTweenWaypointWalkerSettings
    {
        [SerializeField]
        protected T _settings;

        private Tween _runningTween;

        public T Settings
        {
            get => _settings;
            set => _settings = value;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _runningTween.Kill();
        }

        protected abstract Tween GetWalkToTween(Vector3 targetPosition);

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