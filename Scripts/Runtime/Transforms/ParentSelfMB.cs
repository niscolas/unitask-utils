using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.UnityAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Parent Self")]
    public class ParentSelfMB : AutoTriggerMB
    {
        [SerializeField]
        private ReferenceOrTag<Transform> _parent;

        [SerializeField]
        private bool _resetTransform;

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent _onParented;

        public override void Do()
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