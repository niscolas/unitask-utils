using niscolas.UnityUtils.UniTask;
using niscolas.UnityUtils.UnityAtoms;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityAtomsUtils
{
    [CreateAssetMenu
    (
        menuName = Constants.ActionsCreateAssetMenuPath + "(float) => Timed Action"
    )]
    public class DelayedUnityEvent : AtomAction<float>
    {
        [SerializeField]
        private FloatReference _fixedWaitTime;

        [SerializeField]
        private UnityEvent _action;

        public override async void Do(float waitTime)
        {
            await Await.Seconds(waitTime);
            _action?.Invoke();
        }

        public override void Do()
        {
            Do(_fixedWaitTime.Value);
        }
    }
}