
using System;
// using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public Vector2 MovementInput;
    [SerializeField] public bool upMovement = false;

    private BoxCollider playerCollider;

    [Header("Speed")]
    [SerializeField]
    private float speed = 5f;

    [Header("Jumping")]
    [SerializeField]
    private float jumpHeight = 2.0f;
    private float jumpVelocity;


    // Raycast for ground
    [Header("Ground Detection")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float rayDistance;
    [SerializeField] private float rayOffset = 0.3f;

    private float gravity = Math.Abs(Physics.gravity.y);
    private Rigidbody playerRb;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        playerInput = gameObject.GetComponent<PlayerInput>();
        playerCollider = gameObject.GetComponent<BoxCollider>();



        jumpVelocity = Mathf.Sqrt(2 * gravity * jumpHeight);

        playerInput.actions["Move"].performed += OnMove;
        playerInput.actions["Move"].canceled += OnMove;
        playerInput.actions["Jump"].performed += OnJump;

    }

    private void FixedUpdate()
    {
        rayDistance = playerCollider.size.y / 2 + rayOffset;
        Debug.DrawRay(transform.position, Vector3.down * rayDistance, Color.red);
        // movement if not on ladder
        if (!upMovement)
        {
            Vector3 movement = new Vector3(MovementInput.x, 0, 0);
            playerRb.MovePosition(playerRb.position + movement * speed * Time.deltaTime);
        }
        // CheckGrounded();

    }

    void OnMove(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
    }

    void OnJump(InputAction.CallbackContext context)
    {
        if (CheckGrounded())
        {
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, jumpVelocity);
            // grounded = false;
        }
    }

    void OnDestroy()
    {
        playerInput.actions["Move"].performed -= OnMove;
        playerInput.actions["Move"].canceled -= OnMove;
        playerInput.actions["Jump"].performed -= OnJump;
    }

    bool CheckGrounded()
    {
        // Vector3 rayOrigin = transform.position + rayOffset;
        return Physics.Raycast(transform.position, Vector3.down, rayDistance, LayerMask.GetMask("Ground"));
    }


}
