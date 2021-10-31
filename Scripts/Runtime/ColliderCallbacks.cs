using System;
using Cysharp.Threading.Tasks;
using niscolas.UnityExtensions;
using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Extras
{
    public class ColliderCallbacks : CachedMonoBehaviour
    {
        [SerializeField]
        private Collider _collider;

        [Header("Events")]
        [SerializeField]
        private UnityEvent _onColliderDisabled;

        public event Action Disabled;

        private void Start()
        {
            _gameObject.IfUnityNullGetComponent(ref _collider);
            WaitColliderDisable().Forget();
        }

        private async UniTaskVoid WaitColliderDisable()
        {
            await UniTask.WaitWhile(
                () => _collider.enabled,
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