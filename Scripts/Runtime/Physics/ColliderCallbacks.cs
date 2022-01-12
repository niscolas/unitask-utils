using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Extras
{
    public class ColliderCallbacks : CachedMonoBehaviour
    {
        [SerializeField]
        private Collider[] _colliders;

        [Header("Events")]
        [SerializeField]
        private UnityEvent _onColliderDisabled;

        private void Start()
        {
            if (_colliders.IsNullOrEmpty())
            {
                _colliders = _gameObject.GetComponents<Collider>();
            }

            WaitColliderDisable().Forget();
        }

        public event Action Disabled;

        private async UniTaskVoid WaitColliderDisable()
        {
            await UniTask.WaitWhile(
                () => _colliders.Any(c => c.enabled),
                cancellationToken: _gameObject.GetCancellationTokenOnDestroy());

            NotifyColliderDisabled();
            WaitColliderDisable().Forget();
        }

        private void NotifyColliderDisabled()
        {
            Disabled?.Invoke();
            _onColliderDisabled?.Invoke();
        }
    }
}