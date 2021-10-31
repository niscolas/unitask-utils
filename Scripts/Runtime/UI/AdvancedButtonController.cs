using System;
using Cysharp.Threading.Tasks;
using DefaultNamespace;

namespace niscolas.UnityUtils.Extras
{
    public class AdvancedButtonController
    {
        public event Action OnTap;
        public event Action OnDoubleTap;
        public event Action OnHoldStarted;
        public event Action OnHoldEnded;

        private readonly IAdvancedButton _advancedButton;
        private readonly float _maxDoubleTapInterval;
        private readonly float _maxTapTime;
        private readonly float _minHoldTime;

        private bool _isHolding;
        private bool _isHoldAllowed;
        private float _pointerDownTime;
        private float _lastTapTime;

        public AdvancedButtonController(
            IAdvancedButton advancedButton, float minHoldTime, float maxTapTime, float maxDoubleTapInterval)
        {
            _advancedButton = advancedButton;
            _minHoldTime = minHoldTime;
            _maxTapTime = maxTapTime;
            _maxDoubleTapInterval = maxDoubleTapInterval;
        }

        public void OnPointerDown()
        {
            _pointerDownTime = _advancedButton.Time;
            TryHold().Forget();
        }

        private async UniTaskVoid TryHold()
        {
            _isHoldAllowed = true;

            await Await.Seconds(_minHoldTime);

            if (!_isHoldAllowed)
            {
                return;
            }

            OnPointerHoldStarted();
        }

        public void OnPointerUp()
        {
            _isHoldAllowed = false;

            if (CheckIsDoubleTap())
            {
                OnPointerDoubleTap();
            }
            else if (CheckIsTap())
            {
                OnPointerTap();
            }

            if (_isHolding)
            {
                OnPointerHoldEnded();
            }
        }

        private void OnPointerHoldStarted()
        {
            OnHoldStarted?.Invoke();
            _isHolding = true;
        }

        private void OnPointerHoldEnded()
        {
            OnHoldEnded?.Invoke();
        }

        private void OnPointerDoubleTap()
        {
            OnDoubleTap?.Invoke();
        }

        private void OnPointerTap()
        {
            OnTap?.Invoke();
            _lastTapTime = _advancedButton.Time;
        }

        private bool CheckIsDoubleTap()
        {
            float currentTime = _advancedButton.Time;
            return currentTime - _lastTapTime <= _maxDoubleTapInterval;
        }

        private bool CheckIsTap()
        {
            float currentTime = _advancedButton.Time;
            bool result = currentTime - _pointerDownTime <= _maxTapTime;

            return result;
        }
    }
}