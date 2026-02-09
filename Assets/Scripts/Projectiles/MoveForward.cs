using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindFirstObjectByType<PlayerController>().transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = player.position - transform.position;

        // transform.position += direction * Time.deltaTime * moveSpeed;

        // Try a rigid body MovePosition

        // Try Raycasting
    }



}
