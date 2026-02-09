using UnityEngine;

public class EnemyBaseClass : MonoBehaviour
{
    [SerializeField] protected float damageDealt = 5f;
    [SerializeField] protected float damageTaken = 5f;
    [SerializeField] protected float baseHealth = 100f;

    public float DealDamage()
    {
        return damageDealt;
    }

    protected virtual void TakeDamage()
    {
        if (baseHealth - damageTaken > 0)
        {
            baseHealth -= damageTaken;
        }
        else
        {
            DestroySelf();
        }

    }

    protected virtual void DestroySelf()
    {
        Destroy(gameObject);
    }
}
