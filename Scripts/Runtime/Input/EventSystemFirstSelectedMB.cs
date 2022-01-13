using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Event System First Selected")]
    [DisallowMultipleComponent]
    public class EventSystemFirstSelectedMB : AutoTriggerMB
    {
        [SerializeField]
        private GameObject _target;

        private PlayerInput _firstPlayerInput;

        public override void Do()
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(Target);
        }

        private GameObject Target
        {
            get
            {
                if (!_target)
                {
                    _target = gameObject;
                }

                return _target;
            }
        }

        private void OnEnable()
        {
            if (!_firstPlayerInput)
            {
                _firstPlayerInput = PlayerInput.GetPlayerByIndex(0);

                if (!_firstPlayerInput)
                {
                    return;
                }

                _firstPlayerInput.onControlsChanged += PlayerInput_OnControlsChanged;
            }
        }

        private void OnDestroy()
        {
            _firstPlayerInput.onControlsChanged -= PlayerInput_OnControlsChanged;
        }

        private void PlayerInput_OnControlsChanged(PlayerInput playerInput)
        {
            Do();
        }
    }
}