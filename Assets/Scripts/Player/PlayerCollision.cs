using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody2D playerRb;
    void Awake()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Moving Platform"))
        {
            gameObject.transform.parent = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Moving Platform"))
        {
            gameObject.transform.parent = null;
        }
    }

}
