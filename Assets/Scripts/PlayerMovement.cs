using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform orientation;
    private Rigidbody rb;
    private bool jumpPressed;
    private InputAction moveAction;
    private InputAction jumpAction;

    [Header("Movement settings")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float turnSpeed = 5f;
    private Vector3 moveInput;
    private Vector3 moveDirection;

    [Header ("Ground check")]
    [SerializeField] LayerMask ground;
    [SerializeField] bool isGrounded;
    private float halfHeight;

    [Header ("Animation")]
    [SerializeField] Animator animator;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        GetActions();
    }

    void Update()
    {
        ReadInput();
        CheckGrounded();
        //if (moveAction.IsPressed()) animator.SetBool("isWalking", true);
        //else animator.SetBool("isWalking", false);
        if (moveAction.IsPressed()) animator.SetBool("isWalking", true);
        else animator.SetBool("isWalking", false);
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleJumping();
    }

    void HandleMovement()
    {
        moveDirection = orientation.forward * moveInput.y + orientation.right * moveInput.x; 
        //Vector3 targetVelocity = moveDirection * moveSpeed; 
        //rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z); // Can use rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime), however this causes jitter
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
        }
    }

    void HandleJumping()
    {
        if (jumpPressed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        jumpPressed = false;
    }

    void ReadInput()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        if (jumpAction.IsPressed())
        {
            jumpPressed = true;
        }
    }

    void CheckGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, halfHeight + 0.2f, ground);
        //isGrounded = Physics.OverlapBox(groundCheck.position, groundCheckSize, Quaternion.identity, ground).Length > 0;
    }

    void GetActions()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }
}