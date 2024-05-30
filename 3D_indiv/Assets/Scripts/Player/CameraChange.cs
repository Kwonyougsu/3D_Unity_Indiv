using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraChange : MonoBehaviour
{
    public Camera firstCam;
    public Camera ThirdCam;
    bool cam_change = true;

    private void Update()
    {
        if (cam_change)
        {
            firstCam.enabled = true;
            ThirdCam.enabled = false;
        }
        else
        {
            firstCam.enabled =false;
            ThirdCam.enabled = true;
        }
    }

    public void OnChangedCamera(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            cam_change = !cam_change;
        }
    }
}
