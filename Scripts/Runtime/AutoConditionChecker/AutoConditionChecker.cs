using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.UnityAtoms;
using UnityEngine;
using UnityEngine.Events;
using UnityUtils;

namespace niscolas.UnityUtils.Extras
{
    public abstract class AutoConditionChecker<T> : CachedMonoBehaviour
    {
        [SerializeField]
        private MonoCallbackType _conditionCheckMoment = MonoCallbackType.Awake;

        [SerializeField]
        protected AtomConditions<T> _conditions;

        [Header("Events")]
        [SerializeField]
        private UnityEvent _onSuccess;

        [SerializeField]
        private UnityEvent _onFailure;

        protected override void Awake()
        {
            base.Awake();
            MonoLifecycleHooksManager.AutoTrigger(_gameObject, CheckEnvironment, _conditionCheckMoment);
        }

        protected virtual void CheckEnvironment()
        {
            if (_conditions.CallAll(default))
            
            {
                _onSuccess?.Invoke();
            }
            else
            {
                _onFailure?.Invoke();
            }
        }
    }
}