using UnityEngine;

public class InputHandler
{
    public InputStatus inputStatus = InputStatus.Unlocked;
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

    //  calculates player motion every frame
    public void CalculateMotion(bool isGrounded)
    {
        if (inputStatus == InputStatus.Unlocked)
        {
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
    }

    // shoots player at sky
    public void Jump(bool isGrounded)
    {
        if (!isGrounded)
        {
            return;
        }
        playerRigidbody.AddForce(Vector3.up * jumpForce);
    }

    // menu button click event
    public void MenuButton()
    {
        HUDManager.Instance.OpenMenu();
    }

    // restart button click event
    public void RestartButton()
    {
        HUDManager.Instance.RestartButton();
    }

}
