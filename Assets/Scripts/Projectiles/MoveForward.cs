using UnityEditor.Callbacks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    private Rigidbody2D laserRb;

    private Transform player;
    private Vector2 direction;

    private void Awake()
    {
        laserRb = gameObject.GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        player = GameObject.FindFirstObjectByType<PlayerController>().transform;
        direction = (player.position - transform.position).normalized;
        laserRb.linearVelocity = direction * moveSpeed;
    }

}
