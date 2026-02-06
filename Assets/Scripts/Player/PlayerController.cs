
using System;
// using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 MovementInput;
    [SerializeField]
    public bool upMovement = false;
    public bool grounded = true;

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpHeight = 2.0f;
    private float gravity = Math.Abs(Physics.gravity.y);
    private float jumpVelocity;


    public Rigidbody playerRb;
    public PlayerInput playerInput;

    private void Awake()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        playerInput = gameObject.GetComponent<PlayerInput>();

        jumpVelocity = Mathf.Sqrt(2 * gravity * jumpHeight);

        playerInput.actions["Move"].performed += OnMove;
        playerInput.actions["Move"].canceled += OnMove;
        playerInput.actions["Jump"].performed += OnJump;

    }

    private void FixedUpdate()
    {
        // movement if not on ladder
        if (!upMovement)
        {
            Vector3 movement = new Vector3(MovementInput.x, 0, 0);
            transform.position += movement * speed * Time.deltaTime;
        }

    }

    void OnMove(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
    }

    void OnJump(InputAction.CallbackContext context)
    {
        if (grounded)
        {
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, jumpVelocity);
            grounded = false;
        }
    }

    void OnDestroy()
    {
        playerInput.actions["Move"].performed -= OnMove;
        playerInput.actions["Move"].canceled -= OnMove;
        playerInput.actions["Jump"].performed -= OnJump;
    }

}
