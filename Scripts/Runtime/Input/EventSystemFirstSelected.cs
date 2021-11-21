﻿using System;
using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace niscolas.UnityUtils.UnityAtoms
{
    public class EventSystemFirstSelected : AutoTriggerMonoBehaviour
    {
        [SerializeField]
        private GameObject _target;

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

        private PlayerInput _firstPlayerInput;

        private void OnEnable()
        {
            if (!_firstPlayerInput)
            {
                _firstPlayerInput = PlayerInput.GetPlayerByIndex(0);
                _firstPlayerInput.onControlsChanged += PlayerInput_OnControlsChanged;
            }
        }

        private void PlayerInput_OnControlsChanged(PlayerInput playerInput)
        {
            Do();
        }

        public override void Do()
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(Target);
        }

        private void OnDestroy()
        {
            _firstPlayerInput.onControlsChanged -= PlayerInput_OnControlsChanged;
        }
    }
}