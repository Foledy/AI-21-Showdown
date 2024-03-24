using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 5;
    [SerializeField] private float _currentSpeed = 0;
    [SerializeField] private float _acceleration = 0.01f;
    
    private PlayerInput _Input;
    private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;
    private Vector3 _movement;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _Input = new PlayerInput();
        _Input.Player.Move.performed += _ => Move();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnEnable()
    {
        _Input.Player.Enable();
    }

    private void OnDisable()
    {
        _Input.Player.Disable();
    }

    private void Move()
    {
        Acceleration();
        var valuue = _Input.Player.Move.ReadValue<Vector2>();
        _movement = new Vector3(valuue.x, 0, valuue.y);
        _rigidbody.MovePosition(transform.position + _movement * _currentSpeed * Time.fixedDeltaTime);
        AnimationOn();
        AnamationOff();
        Debug.Log(_movement);
    }

    private void Acceleration() 
    {
        if ((_movement.magnitude >= 0.5f))
        {
            _currentSpeed +=  + Time.fixedDeltaTime;
            if(_currentSpeed >= _maxSpeed)
            {
                _currentSpeed = _maxSpeed;
            }
        }
        if (_movement.magnitude <= 0)
        {
            _currentSpeed = 1f;
        }
    }

    private void AnimationOn()
    {
        if (_movement.z >= 1)
        {
            _animator.SetBool("WalcingForward", true);
        }

        if (_movement.z <= -1)
        {
            _animator.SetBool("WalcingBack", true);
        }
        
        if(_movement.x <= -0.8 && (_movement.z <= 0.8))
        {
            _animator.SetBool("LeftForwardDiadonaleStrafeWalking", true);
        }
    }

    private void AnamationOff()
    {
        if (_movement.magnitude == 0)
        {
            _animator.SetBool("WalcingForward", false);
            _animator.SetBool("WalcingBack", false);
            _animator.SetBool("LeftForwardDiadonaleStrafeWalking", false);
        }
    }
}
