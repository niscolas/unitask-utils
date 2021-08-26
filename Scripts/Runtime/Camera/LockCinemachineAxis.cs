using Cinemachine;
using UnityEngine;

[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")]
public class LockCinemachineAxis : CinemachineExtension
{
    [SerializeField]
    private bool _lockX;

    [SerializeField]
    private bool _lockY;

    [SerializeField]
    private bool _lockZ;

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
        if (!enabled || stage != CinemachineCore.Stage.Body)
        {
            return;
        }
         
        Vector3 newPosition = state.RawPosition;

        newPosition.x = _lockX ? _startPosition.x : newPosition.x;
        newPosition.y = _lockY ? _startPosition.y : newPosition.y;
        newPosition.z = _lockZ ? _startPosition.z : newPosition.z;

        state.RawPosition = newPosition;
    }
}

