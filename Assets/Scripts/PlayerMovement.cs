using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement: MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 5;
    [SerializeField] private float _currentSpeed = 2;

    private PlayerInput _input;
    private Rigidbody _rigidbody;

    public Vector3 movement;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _input = new PlayerInput();
        _input.Player.Move.performed += _ => Movement();
    }

    private void FixedUpdate()
    {
        Acceleration();
        Movement();
    }

    private void OnEnable()
    {
        _input.Player.Enable();
    }

    private void OnDisable()
    {
        _input.Player.Disable();
    }

    public void Movement()
    {
        var _valuue = _input.Player.Move.ReadValue<Vector2>();
        movement = new Vector3(_valuue.x, 0, _valuue.y);
        _rigidbody.velocity = movement * _currentSpeed;
        Debug.Log(movement);
    }

    private void Acceleration() 
    {
        if ((movement.magnitude >= 0.5f))
        {
            _currentSpeed +=  + Time.deltaTime;
            if(_currentSpeed >= _maxSpeed)
            {
                _currentSpeed = _maxSpeed;
            }
        }

        if (movement.magnitude <= 0)
        {
            _currentSpeed = 2f;
        }
    }
}
