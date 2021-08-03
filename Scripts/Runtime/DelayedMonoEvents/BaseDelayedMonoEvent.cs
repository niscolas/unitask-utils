using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.UniTask
{
    public class BaseDelayedMonoEvent : MonoBehaviour
    {
        [SerializeField]
        private FramesDelayData _framesDelay;

        [SerializeField]
        private SecondsDelayData _secondsDelay;

        [Header("Events")]
        [SerializeField]
        private UnityEvent _event;

        protected async void Raise()
        {
            await _framesDelay.Wait(gameObject);
            await _secondsDelay.Wait(gameObject);

            _event?.Invoke();
        }
    }
}