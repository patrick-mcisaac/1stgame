using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float damageDealt = 5;
    [SerializeField] protected float currentHealth;
    [SerializeField] protected float maxHealth = 100;

    private GameManager gameManager;

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public virtual void DealDamage(GameObject target)
    {
        if (target.CompareTag("Player"))
        {
            gameManager.playerHealth -= damageDealt;
        }
    }

    public virtual void TakeDamage(float damage)
    {
        if (currentHealth - damage <= 0)
        {
            Die();
        }
        currentHealth -= damage;
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
