using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using niscolas.UnityUtils.Core;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityUtils;

namespace niscolas.UnityUtils.Extras
{
    // TODO move this logic to new ScriptableTween
    public abstract class BaseDOTweenOperation<TFrom, TTo, TOptions> : CachedMonoBehaviour
        where TOptions : struct, IPlugOptions
    {
        [FoldoutGroup("General Settings")]
        [SerializeField]
        private bool _autoStart;

        [FoldoutGroup("General Settings")]
        [ShowIf(nameof(_autoStart))]
        [SerializeField]
        private MonoCallbackType _autoStartMoment;

        [FoldoutGroup("To")]
        [FormerlySerializedAs("_endPositionIsRelative"), SerializeField]
        private bool _toIsRelative;

        [FoldoutGroup("Tween Settings")]
        [SerializeField]
        protected FloatReference _duration;

        [FoldoutGroup("Tween Settings")]
        [SerializeField]
        private Ease _ease;

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

        [FoldoutGroup("Events")]
        [SerializeField]
        private UnityEvent _onComplete;

        [FoldoutGroup("Events")]
        [SerializeField]
        private UnityEvent _onKill;

        [FoldoutGroup("Events")]
        [SerializeField]
        private UnityEvent _onPause;

        [FoldoutGroup("Events")]
        [SerializeField]
        private UnityEvent _onPlay;

        [FoldoutGroup("Events")]
        [SerializeField]
        private UnityEvent _onRewind;

        [FoldoutGroup("Events")]
        [SerializeField]
        private UnityEvent _onStart;

        [FoldoutGroup("Events")]
        [SerializeField]
        private UnityEvent _onUpdate;

        [FoldoutGroup("Events")]
        [SerializeField]
        private UnityEvent _onStepComplete;

        protected abstract TweenerCore<TFrom, TTo, TOptions> GetTweener();

        protected abstract GameObject GetLinkTarget();

        protected override void Awake()
        {
            base.Awake();

            if (_autoStart)
            {
                MonoHookManager.TriggerOnMoment(_gameObject, DoTween, _autoStartMoment);
            }
        }

        public void DoTween()
        {
            SetDefaultOptions(GetTweener());
        }

        protected virtual void AfterSetDefaultOptions(TweenerCore<TFrom, TTo, TOptions> tweener) { }

        private void SetDefaultOptions(TweenerCore<TFrom, TTo, TOptions> tweener)
        {
            tweener
                .SetRelative(_toIsRelative)
                .SetLink(GetLinkTarget(), _linkBehaviour)
                .SetAutoKill(_autoKill)
                .SetLoops(_loopCount.Value, _loopType)
                .SetEase(_ease)
                .OnComplete(() => _onComplete?.Invoke())
                .OnKill(() => _onKill?.Invoke())
                .OnPause(() => _onPause?.Invoke())
                .OnPlay(() => _onPlay?.Invoke())
                .OnRewind(() => _onRewind?.Invoke())
                .OnStart(() => _onStart?.Invoke())
                .OnUpdate(() => _onUpdate?.Invoke())
                .OnStepComplete(() => _onStepComplete?.Invoke());


            AfterSetDefaultOptions(tweener);
        }
    }
}