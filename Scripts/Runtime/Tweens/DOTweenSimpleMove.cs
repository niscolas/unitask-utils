using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using niscolas.UnityUtils.Core;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Serialization;
using UnityUtils;

namespace niscolas.UnityUtils.Extras
{
    // TODO move this logic to new ScriptableTween
    public class DOTweenSimpleMove : CachedMonoBehaviour
    {
        [FoldoutGroup("General Settings")]
        [SerializeField]
        private Transform _target;

        [FoldoutGroup("General Settings")]
        [SerializeField]
        private bool _autoStart;

        [FoldoutGroup("General Settings")]
        [ShowIf(nameof(_autoStart))]
        [SerializeField]
        private LifecycleMoment _autoStartMoment;

        [FoldoutGroup("From")]
        [FormerlySerializedAs("_overwriteStartPosition"), SerializeField]
        private bool _setFrom;

        [FoldoutGroup("From")]
        [FormerlySerializedAs("_startPoint"), SerializeField]
        private Transform _fromPoint;

        [FoldoutGroup("From")]
        [EnableIf(nameof(EnableFromPosition))]
        [FormerlySerializedAs("_startPosition"), SerializeField]
        private Vector3Reference _fromPosition;

        [FoldoutGroup("From")]
        [SerializeField]
        private bool _startPositionIsRelative;

        [FoldoutGroup("To")]
        [SerializeField]
        private Vector3Reference _endPosition;

        [FoldoutGroup("To")]
        [SerializeField]
        private Transform _endPoint;

        [FoldoutGroup("To")]
        [SerializeField]
        private bool _endPositionIsRelative;

        [FoldoutGroup("Tween Settings")]
        [SerializeField]
        private FloatReference _duration;

        [FoldoutGroup("Tween Settings")]
        [SerializeField]
        private Ease _ease;

        [FoldoutGroup("Tween Settings")]
        [SerializeField]
        private bool _isLocal;

        [FoldoutGroup("Tween Settings")]
        [SerializeField]
        private LinkBehaviour _linkBehaviour;

        [FoldoutGroup("Tween Settings")]
        [SerializeField]
        private bool _autoKill;

        [FoldoutGroup("Tween Settings")]
        [SerializeField]
        private IntReference _loopCount;

        [FoldoutGroup("Tween Settings")]
        [SerializeField]
        private LoopType _loopType;

        private bool EnableFromPosition => !_fromPoint;

        private Transform Target
        {
            get
            {
                if (!_target)
                {
                    _target = transform;
                }

                return _target;
            }
        }

        protected override void Awake()
        {
            base.Awake();

            if (_autoStart)
            {
                MonoLifeCycle.TriggerOnMoment(_gameObject, DoTween, _autoStartMoment);
            }
        }

        public void DoTween()
        {
            TweenerCore<Vector3, Vector3, VectorOptions> tweener;
            if (!_isLocal)
            {
                tweener = Target.DOMove(GetEndPosition(), _duration.Value);
            }
            else
            {
                tweener = Target.DOLocalMove(GetEndPosition(), _duration.Value);
            }

            SetDefaultOptions(tweener);
        }

        private void SetDefaultOptions(TweenerCore<Vector3, Vector3, VectorOptions> tween)
        {
            tween
                .SetRelative(_endPositionIsRelative)
                .SetLink(Target.gameObject, _linkBehaviour)
                .SetAutoKill(_autoKill)
                .SetLoops(_loopCount.Value, _loopType)
                .SetEase(_ease);

            if (_setFrom)
            {
                tween.From(GetStartPosition(), true, _startPositionIsRelative);
            }
        }

        private Vector3 GetStartPosition()
        {
            if (_fromPoint)
            {
                return _fromPoint.position;
            }
            else
            {
                return _fromPosition.Value;
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