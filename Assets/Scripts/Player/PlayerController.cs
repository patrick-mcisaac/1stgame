
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 MovementInput;
    [SerializeField]
    private bool upMovement = false;
    public bool grounded = true;

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpHeight = 5;

    public Rigidbody playerRb;
    public PlayerInput playerInput;

    private void Awake()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        playerInput = gameObject.GetComponent<PlayerInput>();

        playerInput.actions["Move"].performed += OnMove;
        playerInput.actions["Move"].canceled += OnMove;
        playerInput.actions["Jump"].performed += OnJump;

    }

    private void FixedUpdate()
    {

        Vector3 movement = new Vector3(MovementInput.x, upMovement ? MovementInput.y : 0, 0);
        transform.position += movement * speed * Time.deltaTime;
    }

    void OnMove(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
    }

    void OnJump(InputAction.CallbackContext context)
    {
        if (grounded)
        {
            playerRb.AddForce(Vector2.up * jumpHeight, ForceMode.Impulse);
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
