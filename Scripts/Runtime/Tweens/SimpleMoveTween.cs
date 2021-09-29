using DG.Tweening;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    // TODO move this logic to new ScriptableTween
    public class SimpleMoveTween : MonoBehaviour
    {
        [SerializeField]
        private bool _overwriteStartPosition;

        [EnableIf(nameof(_overwriteStartPosition))]
        [SerializeField]
        private Vector3Reference _startPosition;

        [EnableIf(nameof(_overwriteStartPosition))]
        [SerializeField]
        private Transform _startPoint;

        [EnableIf(nameof(_overwriteStartPosition))]
        [SerializeField]
        private bool _startPositionIsRelative;

        [SerializeField]
        private Vector3Reference _endPosition;

        [SerializeField]
        private Transform _endPoint;

        [SerializeField]
        private bool _endPositionIsRelative;

        [SerializeField]
        private FloatReference _duration;

        [SerializeField]
        private Ease _ease;

        [SerializeField]
        private IntReference _loopCount;

        [SerializeField]
        private LoopType _loopType;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public void DoTween()
        {
            _transform
                .DOMove(GetEndPosition(), _duration.Value)
                .From(GetStartPosition(), true, CheckStartPositionIsRelative())
                .SetRelative(_endPositionIsRelative)
                .SetLoops(_loopCount.Value, _loopType)
                .SetEase(_ease);
        }

        private Vector3 GetStartPosition()
        {
            if (!_overwriteStartPosition)
            {
                return _transform.position;
            }

            if (_startPoint)
            {
                return _startPoint.position;
            }
            else
            {
                return _startPosition.Value;
            }
        }

        private bool CheckStartPositionIsRelative()
        {
            if (!_overwriteStartPosition)
            {
                return false;
            }
            else
            {
                return _startPositionIsRelative;
            }
        }

        private Vector3 GetEndPosition()
        {
            if (_endPoint)
            {
                return _endPoint.position;
            }
            else
            {
                return _endPosition.Value;
            }
        }
    }
}