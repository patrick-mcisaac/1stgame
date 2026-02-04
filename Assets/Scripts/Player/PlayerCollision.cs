using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerController playerController;
    void Awake()
    {
        playerController = gameObject.GetComponent<PlayerController>();
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
