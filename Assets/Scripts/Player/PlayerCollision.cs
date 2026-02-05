using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody playerRb;
    void Awake()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        playerRb = gameObject.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Set grounded to true in player controller
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerController.grounded = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {

            playerRb.useGravity = false;
            playerRb.linearVelocity = new Vector2(0, 0);
            playerController.upMovement = true;
        }

    }

    // Working on ladder functionality  use ladder enter and exit functions on triggers



}
