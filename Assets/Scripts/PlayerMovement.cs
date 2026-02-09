using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] Transform orientation;
    private Rigidbody rb;

    [Header ("Actions")]
    [SerializeField] InputAction moveAction;
    [SerializeField] InputAction jumpAction;

    [Header("Movement settings")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    private Vector3 moveInput;
    private Vector3 moveDirection;

    [Header ("Ground check")]
    [SerializeField] LayerMask ground;
    [SerializeField] Transform groundCheck;
    [SerializeField] Vector3 groundCheckSize;
    [SerializeField] bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetActions();
    }

    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        CheckGrounded();
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleJumping();
        rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void HandleMovement()
    {
        moveDirection = orientation.forward * moveInput.y + orientation.right * moveInput.x; 
        transform.rotation = orientation.rotation;
    }

    void HandleJumping()
    {
        if (jumpAction.WasPressedThisFrame() && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void CheckGrounded()
    {
        isGrounded = Physics.OverlapBox(groundCheck.position, groundCheckSize, transform.rotation, ground).Length > 0;
    }

    void GetActions()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(groundCheck.position, groundCheckSize);
    }
}