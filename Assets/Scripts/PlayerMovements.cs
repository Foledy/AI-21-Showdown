
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    //переменная для скорость движения игрока
    [SerializeField] private float _speedPlayarMin = 0;
    [SerializeField] private float _speedPlayarMax = 5;
    // переменные для передвижения игрока
    private Rigidbody _rb;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        AnimationOff();
    }

    //метод для разгона игрока
    private void AccelerationPlayar(float _accelerationPlayar) 
    {
        _speedPlayarMin += Time.deltaTime + _accelerationPlayar;
        if (_speedPlayarMin >= _speedPlayarMax)
        {
            _speedPlayarMin = _speedPlayarMax;
        }
    }

    //метод в котором будет происходить движения игрока
    private void PlayerMovement()
    {
        // передвижение WSAD
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.W))
        {
            _rb.MovePosition(transform.position + transform.forward * _speedPlayarMin * Time.fixedDeltaTime);
            _animator.SetBool("WalcingForward", true);
            AccelerationPlayar(0.03f);
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.S))
        {
            _rb.MovePosition(transform.position + transform.forward * -_speedPlayarMin * Time.fixedDeltaTime);
            _animator.SetBool("WalcingBack", true);
            AccelerationPlayar(0.03f);
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.A))
        {
            _rb.MovePosition(transform.position + transform.right * -_speedPlayarMin * Time.fixedDeltaTime);
            _animator.SetBool("LeftWalcing", true);
            AccelerationPlayar(0.03f);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.D))
        {
            _rb.MovePosition(transform.position - transform.right * -_speedPlayarMin * Time.fixedDeltaTime);
            _animator.SetBool("RightWalcing", true);
            AccelerationPlayar(0.03f);
        }

        // передвижение по диагонале
        if (((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))))
        {
            _rb.MovePosition(transform.position + (-transform.right + transform.forward) * _speedPlayarMin * Time.fixedDeltaTime);
            AccelerationPlayar(0f);
        }

        if (((Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))))
        {
            _rb.MovePosition(transform.position + (transform.right + transform.forward) * _speedPlayarMin * Time.fixedDeltaTime);
            AccelerationPlayar(0f);
        }

        if (((Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))))
        {
            _rb.MovePosition(transform.position + (-transform.right +(-transform.forward)) * _speedPlayarMin * Time.fixedDeltaTime);
            AccelerationPlayar(0f);
        }

        if (((Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))))
        {
            _rb.MovePosition(transform.position + (transform.right + (-transform.forward)) * _speedPlayarMin * Time.fixedDeltaTime);
            AccelerationPlayar(0f);
        }
    }

    // метод для выключения анимации 
    private void AnimationOff() 
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            _animator.SetBool("WalcingForward", false);
            _speedPlayarMin = 0;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            _animator.SetBool("WalcingBack", false);
            _speedPlayarMin = 0;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetBool("LeftForwardDiadonaleStrafeWalking", false);
            _speedPlayarMin = 0;
        }
    }
}
