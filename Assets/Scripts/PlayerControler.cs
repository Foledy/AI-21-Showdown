
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //���������� ��� �������� �������� ������
    [SerializeField] private float _speed;
    // ���������� ��� ������������ ������
    private float hInput;
    private float vInput;
    private Rigidbody _rb;

    private void Start()
    {
        hInput = Input.GetAxis("Horizontal");
        
        _rb = GetComponent<Rigidbody>();
    }

    //����� � ������� ����� ����������� �������� ������
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
