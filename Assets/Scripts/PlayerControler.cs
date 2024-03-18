
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //переменная для скорость движения игрока
    [SerializeField] private float _speed;
    // переменные для передвижения игрока
    private float hInput;
    private float vInput;
    private Rigidbody _rb;

    private void Start()
    {
        hInput = Input.GetAxis("Horizontal");
        
        _rb = GetComponent<Rigidbody>();
    }

    //метод в котором будет происходить движения игрока
    private void PlayerMovement()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hInput, 0f, vInput);
        _rb.velocity = movement * _speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }
}
