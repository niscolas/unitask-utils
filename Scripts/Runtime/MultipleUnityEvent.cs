using niscolas.OdinCompositeAttributes;
using niscolas.UnityExtensions;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using UnityUtils;

namespace niscolas.UnityUtils.Extras
{
    public class MultipleUnityEvent : AutoTriggerMonoBehaviour
    {
        [SerializeField]
        private Vector2IntReference _callCountRange = new Vector2IntReference(Vector2Int.one);

        [SecondsLabel, SerializeField]
        private DelayWrapper _delay = new DelayWrapper();
        
        [SecondsLabel, SerializeField]
        private DelayWrapper _callInterval = new DelayWrapper();

        [SerializeField]
        private UnityEvent _event;

        public override async void Do()
        {
            int callCount = _callCountRange.Value.Random();

            await _delay.Delay(gameObject);
            for (int i = 0; i < callCount; i++)
            {
                _event?.Invoke();
                await _callInterval.Delay(gameObject);
            }
        }
    }
}