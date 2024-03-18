
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] Animator animator;
    //переменная для скорость движения игрока
    [SerializeField] private float _speedPlayarMin = 0;
    [SerializeField] private float _speedPlayarMax = 5;
    // переменные для передвижения игрока
    private float hInput;
    private float vInput;
    private Rigidbody _rb;

    private void Start()
    {
        hInput = Input.GetAxis("Horizontal");
        
        _rb = GetComponent<Rigidbody>();
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
        hInput = Input.GetAxis("Horizontal");
      //  vInput = Input.GetAxis("Vertical");
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.W))
        {
            _rb.MovePosition(transform.position + transform.forward * _speedPlayarMin * Time.fixedDeltaTime);
            if(_speedPlayarMin >= 0.1f)
            {
                animator.SetBool("Walcing", true);
            }
            
            AccelerationPlayar(0.03f);
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.S))
        {
            _rb.MovePosition(transform.position + transform.forward * -_speedPlayarMin * Time.fixedDeltaTime);
            animator.SetBool("WalcingBack", true);
            AccelerationPlayar(0.03f);
        }

        if (((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))))
        {
            _rb.MovePosition(transform.position +(-transform.right + transform.forward) * _speedPlayarMin * Time.fixedDeltaTime);
            animator.SetBool("LeftForwardDiadonaleStrafeWalking", true);
            animator.SetBool("Walcing", false);
            AccelerationPlayar(0f);
        }

        if (((Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))))
        {
            _rb.MovePosition(transform.position + (transform.right + transform.forward) * _speedPlayarMin * Time.fixedDeltaTime);
            animator.SetBool("RightStrafeWalking", true);
            animator.SetBool("Walcing", false);
            AccelerationPlayar(0f);
        }



        Vector3 movement = new Vector3(hInput, 0f, vInput);
        _rb.velocity = movement * _speedPlayarMin * Time.deltaTime;
    }
    private void AnimationOff() 
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("Walcing", false);
            _speedPlayarMin = 0;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("WalcingBack", false);
            _speedPlayarMin = 0;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("LeftForwardDiadonaleStrafeWalking", false);
            _speedPlayarMin = 0;
        }
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        AnimationOff();
    }
}
