
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private BoxCollider2D playerCollider;
    [SerializeField] private LayerMask groundLayerMask;
    private float rayCastOffset = .1f;

    [SerializeField] private GameObject bullet;

    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float jumpHeight = 4f;
    private float gravityMultiplier = 1f;

    private PlayerInput playerInput;
    public Vector2 movementInput;
    private PlayerCollisions collisions;

    public bool isOnLadder = false;
    private float climbSpeed = 2f;

    private void Awake()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        playerInput = gameObject.GetComponent<PlayerInput>();
        playerCollider = gameObject.GetComponent<BoxCollider2D>();

        playerRb.gravityScale = gravityMultiplier;


        playerInput.actions["Move"].performed += OnMove;
        playerInput.actions["Move"].canceled += OnMove;
        playerInput.actions["Jump"].performed += OnJump;
        playerInput.actions["Fire"].performed += OnFire;

    }

    private void Start()
    {
        collisions = gameObject.GetComponent<PlayerCollisions>();
        collisions.OnLadder += OnLadder;
        collisions.OffLadder += OffLadder;

    }

    private void FixedUpdate()
    {
        if (!isOnLadder)
        {
            Vector2 movement = new Vector2(movementInput.x, 0);
            playerRb.AddForce(moveSpeed * movement, ForceMode2D.Impulse);
        }
        if (isOnLadder)
        {
            Vector2 movement = new Vector2(0, movementInput.y);

            transform.Translate(movement * climbSpeed * Time.deltaTime);
        }

    }

    private void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        if (movementInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (movementInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (DetectGround())
        {
            float jumpVelocity = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * gravityMultiplier));
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocityX, jumpVelocity);
        }
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    private void OnDestroy()
    {
        playerInput.actions["Move"].performed -= OnMove;
        playerInput.actions["Move"].canceled -= OnMove;
        playerInput.actions["Jump"].performed -= OnJump;
    }

    private bool DetectGround()
    {
        return Physics2D.Raycast(transform.position, -transform.up, playerCollider.size.y / 2 + rayCastOffset, groundLayerMask);
    }

    private void OnLadder(object sender, EventArgs e)
    {
        isOnLadder = true;
        playerRb.gravityScale = 0;
    }

    private void OffLadder(object sender, EventArgs e)
    {
        isOnLadder = false;
        playerRb.gravityScale = gravityMultiplier;
    }
}
