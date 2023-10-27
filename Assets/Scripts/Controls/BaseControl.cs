using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;

public abstract class BaseControl : MonoBehaviour
{
    public WebXRController controller;
    [SerializeField] protected GameObject cameraRef;

    private bool triggerPressed = false;
    private bool gripPressed = false;

    protected Rigidbody rb;

    private void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (controller.GetButtonDown(WebXRController.ButtonTypes.ButtonA))
        {
            OnButtonADown();
        }

        if (controller.GetButtonDown(WebXRController.ButtonTypes.ButtonB))
        {
            OnButtonBDown();
        }


        float grip = controller.GetAxis(WebXRController.AxisTypes.Grip);
        if (grip > 0.25 && !gripPressed)
        {
            OnGripPressed();
            gripPressed = true;
        }
        
        if (grip < 0.25 && gripPressed)
        {
            OnGripReleased();
            gripPressed = false;
        }

        float trigger = controller.GetAxis(WebXRController.AxisTypes.Trigger);
        if (trigger > 0.25 && !triggerPressed)
        {
            OnTriggerPressed();
            triggerPressed = true;
        }

        if (trigger < 0.25 && triggerPressed)
        {
            OnTriggerReleased();
            triggerPressed = false;
        }

        Vector2 joystick = controller.GetAxis2D(WebXRController.Axis2DTypes.Thumbstick);
        OnJoystickMove(joystick);
    }

    public abstract void OnButtonADown();
    public abstract void OnButtonBDown();
    public abstract void OnGripPressed();
    public abstract void OnGripReleased();
    public abstract void OnTriggerPressed();
    public abstract void OnTriggerReleased();
    public abstract void OnJoystickMove(Vector2 joystick);
}
