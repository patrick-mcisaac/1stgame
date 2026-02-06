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

}
