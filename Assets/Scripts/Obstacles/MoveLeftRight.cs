using System.Collections;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    public float movementSpeed = 0.01f;
    private Vector2 startPosition;
    private Vector2 endPosition;
    [SerializeField]
    private float endPositionRangeX;
    [SerializeField]
    private float endPositionRangeY;

    private float fraction = 0;
    private bool atDestination;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        startPosition = gameObject.transform.position;
        endPosition = new Vector2(startPosition.x + endPositionRangeX, startPosition.y + endPositionRangeY);
        atDestination = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fraction < 1)
        {
            fraction += Time.deltaTime * movementSpeed;
            if (!atDestination)
            {
                transform.position = Vector2.Lerp(startPosition, endPosition, fraction);
            }
            else
            {
                transform.position = Vector2.Lerp(endPosition, startPosition, fraction);
            }
        }
        else
        {
            atDestination = !atDestination;
            fraction = -0.5f;
        }

    }


}
