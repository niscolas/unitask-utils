using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Collider Callbacks")]
    public class ColliderCallbacksMB : CachedMB
    {
        [SerializeField]
        private Collider[] _colliders;

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent _onColliderDisabled;

        public event Action Disabled;

        private void Start()
        {
            if (_colliders.IsNullOrEmpty())
            {
                _colliders = _gameObject.GetComponents<Collider>();
            }

            WaitColliderDisable().Forget();
        }

        private void NotifyColliderDisabled()
        {
            Disabled?.Invoke();
            _onColliderDisabled?.Invoke();
        }

        private async UniTaskVoid WaitColliderDisable()
        {
            await UniTask.WaitWhile(
                () => _colliders.Any(c => c.enabled),
                cancellationToken: _gameObject.GetCancellationTokenOnDestroy());

            NotifyColliderDisabled();
            WaitColliderDisable().Forget();
        }
    }
}