using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    [Header("Jump Settings")]
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    private Rigidbody rb;
    private Transform cameraTransform;

    private bool isGrounded;
    private bool jumpRequested = false;
    private float xInput;
    private float zInput;
    private Vector3 movementDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        CheckGrounded();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
        }
    }

    private void FixedUpdate()
    {
        CalculateMovementDirection();
        HandleMovement();
        HandleRotation();
        HandleJumping();
    }

    private void CheckGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    private void CalculateMovementDirection()
    {
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        movementDirection = (camForward * zInput + camRight * xInput).normalized;
    }

    private void HandleMovement()
    {
        float currentYVelocity = rb.linearVelocity.y;
        rb.linearVelocity = new Vector3(movementDirection.x * moveSpeed, currentYVelocity, movementDirection.z * moveSpeed);
    }

    private void HandleRotation()
    {
        if (movementDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            rb.MoveRotation(Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));
        }
    }

    private void HandleJumping()
    {
        if (jumpRequested)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            jumpRequested = false;
        }
    }
}