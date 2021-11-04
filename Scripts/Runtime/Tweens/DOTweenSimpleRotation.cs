using DG.Tweening;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    // TODO move this logic to new ScriptableTween
    public class DOTweenSimpleRotation : MonoBehaviour
    {
        [SerializeField]
        private bool _overwriteStartRotation;

        [EnableIf(nameof(_overwriteStartRotation))]
        [SerializeField]
        private Vector3Reference _startRotation;

        [EnableIf(nameof(_overwriteStartRotation))]
        [SerializeField]
        private bool _startRotationIsRelative;

        [SerializeField]
        private Vector3Reference _endRotation;

        [SerializeField]
        private bool _endRotationIsRelative;

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
            transform
                .DORotate(GetEndRotation(), _duration.Value)
                .From(GetStartRotation(), true, CheckStartRotationIsRelative())
                .SetRelative(_endRotationIsRelative)
                .SetLoops(_loopCount.Value, _loopType)
                .SetEase(_ease);
        }

        private Vector3 GetStartRotation()
        {
            if (!_overwriteStartRotation)
            {
                return _transform.eulerAngles;
            }
            else
            {
                return _startRotation.Value;
            }
        }
        
        private bool CheckStartRotationIsRelative()
        {
            if (!_overwriteStartRotation)
            {
                return false;
            }
            else
            {
                return _startRotationIsRelative;
            }
        }

        private Vector3 GetEndRotation()
        {
            return _endRotation.Value;
        }
    }
}