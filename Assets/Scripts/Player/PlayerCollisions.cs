using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.GetComponentInParent<Projectile>();
        if (projectile != null)
        {
            if (GameManager.Instance.PlayerHealth - projectile.damageDealt > 0)
            {
                GameManager.Instance.PlayerHealth -= projectile.damageDealt;
                projectile.DestroySelf();
                Debug.Log(GameManager.Instance.PlayerHealth);
            }
            else
            {
                Debug.Log("Game Over!");
            }
        }
    }
}
