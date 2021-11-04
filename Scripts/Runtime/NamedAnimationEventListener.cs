using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Extras
{
    public class NamedAnimationEventListener : CachedMonoBehaviour
    {
        [SerializeField]
        private StringReference _eventName;

        [Header("Events")]
        [SerializeField]
        private UnityEvent _onEventTriggered;

        public void AnimationEvent(string eventName)
        {
            if (_eventName.Value != eventName)
            {
                return;
            }

            _onEventTriggered?.Invoke();
        }
    }
}