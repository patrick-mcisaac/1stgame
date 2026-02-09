using System.Collections;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    private float timer = 0;
    public bool startTimer = false;
    private float fallTime = 2f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO: change from compare tag to tryGetComponent
        if (collision.gameObject.CompareTag("Player"))
        {
            startTimer = true;
        }
    }

    void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;

            if (timer > fallTime)
            {
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
    }


}
