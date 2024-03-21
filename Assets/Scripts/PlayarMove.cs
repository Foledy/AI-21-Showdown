using UnityEngine.InputSystem;
using UnityEngine;

public class PlayarMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5;
    private Vector2 _direction;

    private void FixedUpdate()
    {
        Move(_direction);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }

    private void Move(Vector2 directionMove)
    {
        Vector3 direction = new Vector3(directionMove.x, 0, directionMove.y);
        transform.position += direction * _moveSpeed * Time.fixedDeltaTime;
    }
}
