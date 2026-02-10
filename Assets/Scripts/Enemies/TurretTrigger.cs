using System;
using UnityEngine;

public class TurretTrigger : MonoBehaviour
{
    private GameObject player;

    public EventHandler TriggerEnter;
    public EventHandler TriggerExit;

    private void Start()
    {
        player = GameObject.FindFirstObjectByType<PlayerController>().gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            TriggerEnter?.Invoke(this, EventArgs.Empty);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            TriggerExit?.Invoke(this, EventArgs.Empty);
        }
    }
}