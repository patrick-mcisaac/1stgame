using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] public float damageDealt;

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

}
