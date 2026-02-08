using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 direction;
    private GameObject player;
    [SerializeField]
    private float projectileSpeed = 15f;

    public GameObject childProjectile;
    void Awake()
    {
        player = GameObject.Find("Player");
        direction = (player.transform.position - transform.position).normalized;
        childProjectile.transform.LookAt(player.transform.position);
        transform.Rotate(0, 0, 90);
    }

    void Update()
    {
        transform.position += direction * Time.deltaTime * projectileSpeed;
    }

}