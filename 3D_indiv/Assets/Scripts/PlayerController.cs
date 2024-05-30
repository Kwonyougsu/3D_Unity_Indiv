using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllar : MonoBehaviour
{
    #region Header
    [Header("Movement")]
    public float speed;
    private Vector2 curMovement;
    public float JumpPower;
    public LayerMask groundLayerMask;

    private Rigidbody rb;

    [Header("Look")]
    public Transform camara;
    public float minLook;
    public float maxLook;
    private float camCurLook;
    public float Sensititiy;
    private Vector2 mouse;

    #endregion

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

    #region Player Move
    public void Onmove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovement = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
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
    #endregion

    #region PlayerLook
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

    #endregion

    #region PlayerJump / ray를 적용하면 이상해짐, 이유를 모르겠습니다?
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            rb.AddForce(Vector2.up * JumpPower, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) +(transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }

        return false;
    }

    #endregion
}
