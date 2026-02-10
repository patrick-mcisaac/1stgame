using System;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    public EventHandler OnLadder;
    public EventHandler OffLadder;

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

        if (collision.TryGetComponent<Ladder>(out Ladder ladder))
        {
            OnLadder?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ladder>(out Ladder ladder))
        {
            OffLadder?.Invoke(this, EventArgs.Empty);
        }
    }
}
