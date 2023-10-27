using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RightController : BaseControl
{
    private bool rotated = false;

    [SerializeField] private Transform rotateContainer;

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
        Rotation(joystick);
    }

    private void Rotation(Vector2 input)
    {
        if (input.x < 0.3f && input.x > -0.3f)
        {
            rotated = false;
        }

        if (rotated) return;

        float direction = 0f;
        if (input.x > 0.3f)
        {
            direction = 1f;
            rotated = true;
        }
        else if (input.x < -0.3f)
        {
            direction = -1f;
            rotated = true;
        }

        Vector3 actualRot = rotateContainer.rotation.eulerAngles;
        Vector3 newRot = new Vector3(0, actualRot.y + (45 * direction), 0);

        rotateContainer.rotation = Quaternion.Euler(newRot);
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
