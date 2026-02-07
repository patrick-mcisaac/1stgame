using System.Collections;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    private float timer = 0;
    public bool startTimer = false;
    private float fallTime = 2f;

    void OnCollisionEnter(Collision collision)
    {
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
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
        }
    }


}
