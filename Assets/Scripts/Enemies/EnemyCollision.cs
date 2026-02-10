using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent<PlayerBullet>(out PlayerBullet bullet))
        {
            bullet.DestroySelf();
            gameObject.GetComponent<EnemyBaseClass>().TakeDamage();

            // trigger for player detection causing issues. find new way to do that
        }
    }
}