using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Named Animation Event Listener")]
    public class NamedAnimationEventListenerMB : CachedMonoBehaviour
    {
        [SerializeField]
        private StringReference _eventName;

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent _onTriggered;

        public void AnimationEvent(string eventName)
        {
            if (_eventName.Value != eventName)
            {
                return;
            }

            _onTriggered?.Invoke();
        }
    }
}