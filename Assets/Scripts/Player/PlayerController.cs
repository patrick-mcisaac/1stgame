
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 MovementInput;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private bool upMovement = false;


    void OnMove(InputValue context)
    {
        MovementInput = context.Get<Vector2>();
    }

    private void FixedUpdate()
    {

        Vector3 movement = new Vector3(MovementInput.x, upMovement ? MovementInput.y : 0, 0);
        transform.position += movement * speed * Time.deltaTime;
    }

}
