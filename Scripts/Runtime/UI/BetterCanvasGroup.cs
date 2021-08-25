using DG.Tweening;
using niscolas.UnityExtensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Extras
{
    public class BetterCanvasGroup : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;

        [SerializeField]
        private FloatReference _fadeDuration;

        [SerializeField]
        private Ease _fadeEase;

        [SerializeField]
        private BoolReference _useIndependentUpdate;

        private Tween _fadeInTween;
        private Tween _fadeOutTween;

        private void Start()
        {
            if (!_canvasGroup)
            {
                Debug.LogWarning("no CanvasGroup, self destroying");
                Destroy(gameObject);
                return;
            }

            CacheTweens();
        }

        private void CacheTweens()
        {
            _fadeInTween = _canvasGroup
                .DOFade(1, _fadeDuration.Value)
                .SetEase(_fadeEase)
                .SetAutoKill(false)
                .SetUpdate(_useIndependentUpdate.Value)
                .OnComplete(
                    () =>
                        _canvasGroup.SetInteractableAndBlocksRaycasts(true)
                    )
                .Pause();

            _fadeOutTween = _canvasGroup
                .DOFade(0, _fadeDuration.Value)
                .SetEase(_fadeEase)
                .SetAutoKill(false)
                .SetUpdate(_useIndependentUpdate.Value)
                .OnComplete(
                    () =>
                        _canvasGroup.SetInteractableAndBlocksRaycasts(false)
                    )
                .Pause();
        }

        public void Show()
        {
            _fadeInTween.Restart();
        }

        public void Hide()
        {
            _fadeOutTween.Restart();
        }
    }
}
