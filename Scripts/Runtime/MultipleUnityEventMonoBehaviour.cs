using niscolas.OdinCompositeAttributes;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Multiple Unity Event")]
    public class MultipleUnityEventMonoBehaviour : AutoTriggerMonoBehaviour
    {
        [SerializeField]
        private Vector2IntReference _callCountRange = new(Vector2Int.one);

        [SecondsLabel]
        [SerializeField]
        private DelayWrapper _delay = new();

        [SecondsLabel]
        [SerializeField]
        private DelayWrapper _callInterval = new();

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