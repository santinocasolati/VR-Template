using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftController : BaseControl
{
    [SerializeField] private GameObject moveContainer;
    public float moveSpeed = 0.005f;

    public override void OnButtonADown()
    {
        Debug.Log("Button A Down");
    }

    public override void OnButtonBDown()
    {
        Debug.Log("Button B Down");
    }

    public override void OnGripPressed()
    {
        Debug.Log("Grip pressed");
    }

    public override void OnGripReleased()
    {
        Debug.Log("Grip released");
    }

    public override void OnJoystickMove(Vector2 joystick)
    {
        Movement(joystick);
    }

    private void Movement(Vector2 input)
    {
        float runningX = 1f;
        float runningY = 1f;
        float directionX = 0f;
        float directionY = 0f;

        if (input.x > 0f)
        {
            directionX = 1f;
        } else if (input.x < 0f)
        {
            directionX = -1f;
        }

        if (Mathf.Abs(input.x) > 0.8f)
        {
            runningX = 2f;
        }

        if (input.y > 0f)
        {
            directionY = 1f;
        }
        else if (input.y < 0f)
        {
            directionY = -1f;
        }

        if (Mathf.Abs(input.y) > 0.8f)
        {
            runningY = 2f;
        }

        Vector3 moveX = cameraRef.transform.right * directionX * (moveSpeed * 10f * runningX);
        Vector3 moveY = cameraRef.transform.forward * directionY * (moveSpeed * 10f * runningY);

        Vector3 moveFinal = moveContainer.transform.position + moveX + moveY;
        moveFinal.y = moveContainer.transform.position.y;
        rb.MovePosition(moveFinal);
    }

    public override void OnTriggerPressed()
    {
        Debug.Log("Trigger pressed");
    }

    public override void OnTriggerReleased()
    {
        Debug.Log("Trigger released");
    }
}
