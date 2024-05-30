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
    private bool HighJump = false;

    private Rigidbody rb;

    [Header("Look")]
    public Transform camara;
    public float minLook;
    public float maxLook;
    private float camCurLook;
    public float Sensititiy;
    private Vector2 mouse;

    
    #endregion

    
    public Animator animator;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        UpdateAnimation();
    }
    private void FixedUpdate()
    {
        Move();
        CheckGrounded();
    }

    private void UpdateAnimation()
    {
        Vector3 horizontalMovement = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        float currentSpeed = horizontalMovement.magnitude;
        animator.SetFloat("Speed", currentSpeed);
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

    #region PlayerJump / ray를 적용하면 이상해짐, 이유를 모르겠습니다? => Ray가 짧아서 점프를 하지 않음 ray 수정함
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && IsGrounded())
        {
            if (HighJump)
            {
                rb.AddForce(Vector2.up * JumpPower * 3, ForceMode.Impulse);
                HighJump = false;
            }
            else
            {
                rb.AddForce(Vector2.up * JumpPower, ForceMode.Impulse);
            }
            animator.SetBool("Jump", true);
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
            if (Physics.Raycast(rays[i], 0.14f, groundLayerMask))
            {
                return true;
            }
        }
        return false;
    }

    private void CheckGrounded()
    {
        bool grounded = IsGrounded();
        //animator.SetBool("IsGrounded", grounded);

        if (grounded)
        {
            animator.SetBool("Jump", false);
        }
    }

    #endregion

    #region 점프대
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jump"))
        {
            HighJump = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jump"))
        {
            HighJump = false;
        }
    }
    #endregion


}
