using Unity.VisualScripting;
using UnityEngine;

public class Laser : Projectile
{
    [SerializeField] private GameObject childProjectile;
    protected override void Awake()
    {
        base.Awake();
        childProjectile.transform.LookAt(player.transform.position);
        transform.Rotate(0, 0, 90);
    }
}