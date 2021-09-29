using System;
using niscolas.UnityExtensions;
using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityUtils;

namespace niscolas.UnityUtils.Extras
{
    public class AddToCameraStack : MonoBehaviour
    {
        [SerializeField]
        private Camera _cameraToAdd;

        [SerializeField]
        private LifecycleMoment _addMoment = LifecycleMoment.Awake;

        private GameObject _gameObject;

        private void Awake()
        {
            _gameObject = gameObject;
            _gameObject.IfUnityNullGetComponent(ref _cameraToAdd);
            MonoLifeCycle.TriggerOnMoment(_gameObject, Add, _addMoment);
        }

        private void Add()
        {
            Camera.main.GetUniversalAdditionalCameraData().cameraStack.Add(_cameraToAdd);
        }
    }
}