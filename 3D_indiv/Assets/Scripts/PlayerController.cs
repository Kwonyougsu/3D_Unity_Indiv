using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllar : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    private Vector2 curMovement;

    private Rigidbody rb;

    [Header("Look")]
    public Transform camara;
    public float minLook;
    public float maxLook;
    private float camCurLook;
    public float Sensititiy;
    private Vector2 mouse;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        CamaraLook();
    }

    public void Onmove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            curMovement = context.ReadValue<Vector2>();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            curMovement = Vector2.zero;
        }
    }
    private void Move()
    {
        Vector3 dir = transform.forward * curMovement.y + transform.right * curMovement.x;
        dir *= speed;
        dir.y = rb.velocity.y;

        rb.velocity = dir;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouse = context.ReadValue<Vector2>();
    }

    void CamaraLook()
    {
        camCurLook += mouse.y * Sensititiy;
        camCurLook = Mathf.Clamp(camCurLook, minLook,maxLook);
        camara.localEulerAngles = new Vector3(-camCurLook, 0, 0);

        transform.eulerAngles += new Vector3(0, mouse.x * Sensititiy, 0);
    }

}
