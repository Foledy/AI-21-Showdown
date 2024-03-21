using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform target; // ���� (������ �����)
    [SerializeField] private float sensitivity = 2f; // ���������������� ����
    [SerializeField] private float distance = 5f; // ���������� �� ����
    [SerializeField] private float height = 2f; // ������ ��� �����

    private float currentX = 0f;
    private float currentY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // �������� ���� � ����
        currentX += Input.GetAxis("Mouse X") * sensitivity;
        currentY -= Input.GetAxis("Mouse Y") * sensitivity;

        // ������������ ������������ ��������
        currentY = Mathf.Clamp(currentY, -90f, 90f);

        // ������� ������ ������ � �������
        target.rotation = Quaternion.Euler(0, currentX, 0);
    }

    void LateUpdate()
    {
        // ��������� ������� ������
        Vector3 dir = new Vector3(0, height, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 position = target.position + rotation * dir;

        // ������������� ������� ������
        transform.position = position;
        transform.LookAt(target);
    }
}
