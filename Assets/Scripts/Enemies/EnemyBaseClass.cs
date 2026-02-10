using UnityEngine;

public class EnemyBaseClass : MonoBehaviour
{

    [SerializeField] protected float damageTaken = 20f;
    [SerializeField] protected float baseHealth = 100f;


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
