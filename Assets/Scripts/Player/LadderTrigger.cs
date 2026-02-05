using UnityEngine;

public class LadderTrigger : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody playerRb;

    void Awake()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        playerRb = gameObject.GetComponentInParent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
    }
}
