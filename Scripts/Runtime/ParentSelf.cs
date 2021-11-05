using niscolas.UnityUtils.Core;
using Plugins.UnityAtomsUtils.Scripts.MonoBehaviourHelpers;
using UnityEngine;
using UnityEngine.Events;
using UnityUtils;

namespace niscolas.UnityUtils.Extras
{
    public class ParentSelf : CachedMonoBehaviour
    {
        [SerializeField]
        private ReferenceOrTag<Transform> _parent;

        [SerializeField]
        private bool _resetTransform;

        [SerializeField]
        private MonoCallbackType _moment = MonoCallbackType.Start;

        [Header("Events")]
        [SerializeField]
        private UnityEvent _onParented;

        protected override void Awake()
        {
            base.Awake();
            MonoHookManager.TriggerOnMoment(_gameObject, Do, _moment);
        }

        private void Do()
        {
            _transform.SetParent(_parent.Value);

            if (!_resetTransform)
            {
                _onParented?.Invoke();
                return;
            }

            _transform.localPosition = Vector3.zero;
            _transform.localRotation = Quaternion.identity;
            _transform.localScale = Vector3.one;
            _onParented?.Invoke();
        }
    }
}