using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //���������� ��� �������� �������� ������
    [SerializeField] private float _speed;
    //
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    //����� � ������� ����� ����������� �������� ������
    private void PlayerMovement()
    {
        //�������� ������, �����, ������, �����
        if(Input.GetKey(KeyCode.W))
        {
            _rb.MovePosition(transform.position + transform.forward * _speed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rb.MovePosition(transform.position + transform.forward * -_speed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rb.MovePosition(transform.position + transform.right * _speed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rb.MovePosition(transform.position + transform.right * -_speed * Time.fixedDeltaTime);
        }

        //�������� �� ��������� 
      


    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }
}
