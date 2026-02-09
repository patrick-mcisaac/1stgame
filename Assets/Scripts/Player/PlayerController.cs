using System;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float jumpHeight = 4f;
    private float gravityMultiplier = 1f;

    private PlayerInput playerInput;
    private Vector2 movementInput;

    private void Awake()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        playerInput = gameObject.GetComponent<PlayerInput>();
        playerRb.gravityScale = gravityMultiplier;

        playerInput.actions["Move"].performed += OnMove;
        playerInput.actions["Move"].canceled += OnMove;
        playerInput.actions["Jump"].performed += OnJump;
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(movementInput.x, 0);
        playerRb.AddForce(moveSpeed * movement, ForceMode2D.Impulse);

    }

    private void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        float jumpVelocity = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * gravityMultiplier));
        playerRb.linearVelocity = new Vector2(playerRb.linearVelocityX, jumpVelocity);
    }

    private void OnDestroy()
    {
        playerInput.actions["Move"].performed -= OnMove;
        playerInput.actions["Move"].canceled -= OnMove;
        playerInput.actions["Jump"].performed -= OnJump;
    }
}
