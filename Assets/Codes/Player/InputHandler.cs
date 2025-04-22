using UnityEngine;

public class InputHandler
{
    public InputStatus inputStatus;

    private float movementSpeed = 20.0f;
    private float maxSpeed = 10.0f;
    private float jumpForce = 550.0f;
    private Joystick inGameJoystick;
    private Rigidbody playerRigidbody;

    public InputHandler(Rigidbody playerRigidbody)
    {
        this.playerRigidbody = playerRigidbody;
    }

    public enum InputStatus
    {
        Locked,
        Unlocked,
        InUse
    }

    // joystick setter
    public void SetJoystick(Joystick joystick)
    {
        inGameJoystick = joystick;
    }

    // movementSpeed setter
    public void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }


    public void CalculateMotion(bool isGrounded)
    {
        Debug.Log($"Player speed : {playerRigidbody.velocity.magnitude}");
        if (isGrounded)
        {
            Vector2 joystickDir = new Vector2(inGameJoystick.Direction.x, inGameJoystick.Direction.y);
            if (joystickDir.magnitude > 0 && playerRigidbody.velocity.magnitude < maxSpeed)
            {
                playerRigidbody.AddForce(new Vector3(joystickDir.x, 0, joystickDir.y) * movementSpeed);
                playerRigidbody.drag = 0.05f;
                playerRigidbody.angularDrag = 0.05f;
            }
            else
            {
                playerRigidbody.drag = 5.0f;
                playerRigidbody.angularDrag = 5.0f;
            }
        }
        else 
        {
            playerRigidbody.drag = 0.0f;
            playerRigidbody.angularDrag = 0.0f;
        }
    }
    public void Jump(bool isGrounded)
    {
        if (!isGrounded)
        {
            return;
        }
        playerRigidbody.AddForce(Vector3.up * jumpForce);
    }
}
