using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Named Animation Event Listener")]
    public class NamedAnimationEventListenerMonoBehaviour : CachedMonoBehaviour
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