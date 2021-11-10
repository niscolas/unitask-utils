using niscolas.OdinCompositeAttributes;
using niscolas.UnityUtils.Extras;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace UnityUtils
{
    public class DelayedUnityEvent : MonoBehaviour
    {
        [FormerlySerializedAs("_delaySec"), SecondsLabel, SerializeField]
        private FloatReference _secondsDelay;
        
        [SerializeField]
        private IntReference _framesDelay;

        [SerializeField]
        private UnityEvent _event;

        public async void Do()
        {
            await Await.Frames(_framesDelay.Value);
            await Await.Seconds(_secondsDelay, gameObject);
            _event?.Invoke();
        }
    }
}