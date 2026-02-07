using UnityEngine;

public class LadderTrigger : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody playerRb;
    public float speedUpDown = 3.2f;

    void Awake()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        playerRb = gameObject.GetComponent<Rigidbody>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder Trigger"))
        {
            playerController.upMovement = !playerController.upMovement;
            playerRb.useGravity = !playerRb.useGravity;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder Trigger"))
        {
            playerController.upMovement = !playerController.upMovement;
            playerRb.useGravity = !playerRb.useGravity;
        }
    }

    void FixedUpdate()
    {

        // Movement if on ladder
        if (playerController.upMovement)
        {
            playerRb.linearVelocity = new Vector3(0, 0, 0);
            Vector3 movement = new Vector3(0, playerController.MovementInput.y, 0);
            playerRb.MovePosition(transform.position + movement * speedUpDown * Time.deltaTime);
        }
    }
}
