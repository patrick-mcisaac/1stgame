using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Alien : Enemy
{
    /* Class for aliens */
    [SerializeField]
    private float maxDistance = 11f;
    private GameObject player;
    public GameObject projectile;
    private bool isInRange = false;
    private bool isFiring = false;
    private float fireRate = 2f;


    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        // draw ray for debugging raycast length
        // Debug.DrawRay(transform.position, (player.transform.position - transform.position).normalized * maxDistance, Color.blue, .01f);

        CheckPlayerDistance();

        if (isInRange && !isFiring)
        {
            StartCoroutine(SpawnProjectile());
        }
    }

    private void CheckPlayerDistance()
    {
        isInRange = Physics2D.Raycast(transform.position, player.transform.position - transform.position, maxDistance, LayerMask.GetMask("Player"));
    }

    IEnumerator SpawnProjectile()
    {
        isFiring = true;
        while (isInRange)
        {
            yield return new WaitForSeconds(fireRate);
            Instantiate(projectile, transform.position, transform.rotation);
        }

        yield return null;
    }
}