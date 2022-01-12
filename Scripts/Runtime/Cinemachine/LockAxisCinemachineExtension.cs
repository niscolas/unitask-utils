using Cinemachine;
using UnityEngine;
using UnityEngine.Animations;

namespace niscolas.UnityUtils.Extras
{
    [AddComponentMenu("")]
    [ExecuteInEditMode]
    [SaveDuringPlay]
    public class LockAxisCinemachineExtension : CinemachineExtension
    {
        [SerializeField]
        private Axis _lockedAxes;

        private Vector3 _startPosition;

        protected override void Awake()
        {
            base.Awake();
            _startPosition = transform.position;
        }

        protected override void PostPipelineStageCallback(
            CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (!enabled || _lockedAxes.HasFlag(Axis.None) || stage != CinemachineCore.Stage.Body)
            {
                return;
            }

            Vector3 newPosition = state.RawPosition;

            newPosition.x = _lockedAxes.HasFlag(Axis.X) ? _startPosition.x : newPosition.x;
            newPosition.y = _lockedAxes.HasFlag(Axis.Y) ? _startPosition.y : newPosition.y;
            newPosition.z = _lockedAxes.HasFlag(Axis.Z) ? _startPosition.z : newPosition.z;

            state.RawPosition = newPosition;
        }
    }
}