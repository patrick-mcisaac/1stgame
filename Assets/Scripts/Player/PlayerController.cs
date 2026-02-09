using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpHeight = 5f;

    private PlayerInput playerInput;
    private Vector2 movementInput;

    private void Awake()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        playerInput = gameObject.GetComponent<PlayerInput>();



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
        playerRb.AddForce(jumpHeight * Vector2.up, ForceMode2D.Impulse);
    }

    private void OnDestroy()
    {
        playerInput.actions["Move"].performed -= OnMove;
        playerInput.actions["Move"].canceled -= OnMove;
        playerInput.actions["Jump"].performed -= OnJump;
    }
}
