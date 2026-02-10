using System;
using UnityEditor.PackageManager;
using UnityEngine;

public class TurretTrigger : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public EventHandler TriggerEnter;
    public EventHandler TriggerExit;

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