using Unity.VisualScripting;
using UnityEngine;

public class LookToPlayer : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindFirstObjectByType<PlayerController>().gameObject;

        Vector3 direction = player.transform.position - transform.position;

        float angleRadians = Mathf.Atan2(direction.y, direction.x);

        float angleDegrees = angleRadians * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angleDegrees);
        transform.rotation = targetRotation;
    }
}