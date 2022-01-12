using niscolas.UnityUtils.Core.Extensions;
using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Add to Camera Stack")]
    [DisallowMultipleComponent]
    public class AddToCameraStackMonoBehaviour : AutoTriggerMonoBehaviour
    {
        [SerializeField]
        private Camera _cameraToAdd;

        protected override void Awake()
        {
            base.Awake();

            _gameObject.IfUnityNullGetComponent(ref _cameraToAdd);
        }

        public override void Do()
        {
            Camera.main.GetUniversalAdditionalCameraData().cameraStack.Add(_cameraToAdd);
        }
    }
}