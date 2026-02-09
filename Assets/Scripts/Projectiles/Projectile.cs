using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected Vector3 direction;
    protected GameObject player;
    [SerializeField]
    protected float projectileSpeed = 15f;



    protected virtual void Awake()
    {
        player = GameObject.Find("Player");
        direction = (player.transform.position - transform.position).normalized;

    }

    protected virtual void Update()
    {
        transform.position += projectileSpeed * direction * Time.deltaTime;
    }

}