using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody2D bulletRb;
    private GameObject player;
    private Vector2 direction;

    private void Awake()
    {
        bulletRb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        player = GameObject.FindFirstObjectByType<PlayerController>().gameObject;

        direction = player.transform.right;
        bulletRb.linearVelocity = direction * speed;

    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

}
