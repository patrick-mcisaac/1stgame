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


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Moving Platform"))
        {
            gameObject.transform.parent = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Moving Platform"))
        {
            gameObject.transform.parent = null;
        }
    }

}
