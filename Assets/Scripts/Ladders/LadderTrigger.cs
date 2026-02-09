using UnityEngine;

public class LadderTrigger : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody2D playerRb;
    public float speedUpDown = 3.2f;

    void Awake()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        playerRb = gameObject.GetComponent<Rigidbody2D>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Ladder>(out Ladder ladder))
        {
            playerController.upMovement = !playerController.upMovement;
            playerRb.gravityScale = 0;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Ladder>(out Ladder ladder))
        {
            playerController.upMovement = !playerController.upMovement;
            playerRb.gravityScale = 1;
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
