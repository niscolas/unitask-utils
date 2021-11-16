using niscolas.UnityUtils.Core;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    public class KeepRelativePosition : AutoTriggerMonoBehaviour
    {
        [Required, SerializeField]
        private Transform _target;

        [SerializeField]
        private bool _useFixedOffset;

        [ShowIf(nameof(_useFixedOffset)), SerializeField]
        private Vector3Reference _fixedOffset = new Vector3Reference();

        private Vector3 _offset;
        private bool _isOffsetCached;

        public override void Do()
        {
            Vector3 targetPosition = _target.position;

            CacheOffset(targetPosition);

            _transform.position = targetPosition + _offset;
        }

        private void CacheOffset(Vector3 targetPosition)
        {
            if (_isOffsetCached)
            {
                return;
            }

            if (_useFixedOffset)
            {
                _offset = _fixedOffset.Value;
            }
            else
            {
                _offset = _transform.position - targetPosition;
            }

            _isOffsetCached = true;
        }
    }
}