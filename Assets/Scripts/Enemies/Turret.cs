using System;
using System.Collections;
using UnityEngine;

public class Turret : EnemyBaseClass
{
    [SerializeField] private GameObject laser;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private TurretTrigger turretTrigger;

    private bool inRange = false;

    private GameObject player;


    private void Start()
    {
        player = FindFirstObjectByType<PlayerController>().gameObject;

        turretTrigger.TriggerEnter += Trigger_TriggerEnter;
        turretTrigger.TriggerExit += Trigger_TriggerExit;
    }

    private IEnumerator Fire()
    {
        while (inRange)
        {
            Instantiate(laser, transform.position, transform.rotation);
            yield return new WaitForSeconds(2f);
        }

    }

    private void Trigger_TriggerEnter(object sender, EventArgs e)
    {
        inRange = true;
        StartCoroutine(Fire());
    }

    private void Trigger_TriggerExit(object sender, EventArgs e)
    {
        inRange = false;
    }

    private void TrackPlayer()
    {
        // set up tracking while in range
    }
}