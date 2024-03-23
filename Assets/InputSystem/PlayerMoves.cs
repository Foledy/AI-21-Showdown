using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    [SerializeField] private float _speedPlayer;
    private PlayerInput playerInput;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = new PlayerInput();
        playerInput.Player.Move.performed += _ => Move();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnEnable()
    {
        playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }

    // метод для передвижения игрока WSAD и стрелки
    private void Move()
    {
        var valuue = playerInput.Player.Move.ReadValue<Vector2>();
        Vector3 movement = new Vector3(valuue.x, 0, valuue.y);
        rb.AddForce(movement * _speedPlayer);
    }
}
