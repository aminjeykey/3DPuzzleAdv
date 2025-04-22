using System;
using UnityEngine;

// The class for containing and controlling player attributes
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] inventory;
    [SerializeField]
    private Joystick joystick;
    [SerializeField]
    private Rigidbody playerRigidbody;
    [SerializeField]
    private Camera topDownCamera;
    [SerializeField]
    private Transform cameraHolder;
    [SerializeField]
    private Transform lookAtPosition;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float camMovementSmoothness = 0.2f;
    private InputHandler playerInputHandler;
    private CameraController cameraController;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new GameObject[5];
        if (playerRigidbody == null)
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }
        if (cameraController == null)
        {
            cameraController = new CameraController(topDownCamera);
        }
        playerRigidbody.useGravity = true;
        playerInputHandler = new InputHandler(playerRigidbody);
        playerInputHandler.SetJoystick(joystick);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckGrounded();
        playerInputHandler.CalculateMotion(isGrounded);
        cameraController.UpdateCameraMovement(cameraHolder.position, lookAtPosition.position, camMovementSmoothness);
    }

    public void Jump()
    {
        playerInputHandler.Jump(isGrounded);
    }

    private void CheckGrounded()
    {
        isGrounded = Physics.Linecast(transform.position, transform.position + (Vector3.down * 2.0f));
    }
}
