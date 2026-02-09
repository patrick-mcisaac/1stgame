
using System;
// using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public Vector2 MovementInput;
    [SerializeField] public bool upMovement = false;

    private BoxCollider2D playerCollider;

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

    private float gravity;
    private Rigidbody2D playerRb;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        playerInput = gameObject.GetComponent<PlayerInput>();
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
        gravity = Math.Abs(Physics2D.gravity.y);


        jumpVelocity = Mathf.Sqrt(2 * gravity * jumpHeight);

        playerInput.actions["Move"].performed += OnMove;
        playerInput.actions["Move"].canceled += OnMove;
        playerInput.actions["Jump"].performed += OnJump;

    }

    private void FixedUpdate()
    {
        rayDistance = playerCollider.size.y / 2 + rayOffset;
        // movement if not on ladder
        if (!upMovement)
        {
            Vector2 movement = new Vector2(MovementInput.x, 0);
            playerRb.MovePosition(playerRb.position + movement * speed * Time.deltaTime);
        }


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

        }
    }

    private bool CheckGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, rayDistance, LayerMask.GetMask("Ground"));
    }
    void OnDestroy()
    {
        playerInput.actions["Move"].performed -= OnMove;
        playerInput.actions["Move"].canceled -= OnMove;
        playerInput.actions["Jump"].performed -= OnJump;
    }

}
