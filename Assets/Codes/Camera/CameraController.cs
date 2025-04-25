using UnityEngine;

public class CameraController
{
    [SerializeField]
    private Camera thirdPersonCamera;
    [SerializeField]
    private Vector3 cameraOffset = Vector3.zero;
    private Transform cameraTransform;

    public CameraController(Camera thirdPersonCamera)
    {
        this.thirdPersonCamera = thirdPersonCamera;
        cameraTransform = thirdPersonCamera.transform;
    }

    // Changes camera fov real-time
    public void SetCameraFOV(float FOV)
    {
        thirdPersonCamera.fieldOfView = FOV;
    }

    // Method for updating camera's movement and rotation
    public void UpdateCameraMovement(Vector3 playerPosition, Vector3 lookAtPosition, float cameraSmoothness)
    {
        Vector3 nextCamPosition = playerPosition + cameraOffset;
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, nextCamPosition, cameraSmoothness);
        cameraTransform.LookAt(lookAtPosition);
    }
}
