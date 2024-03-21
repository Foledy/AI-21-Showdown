using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform target; // Цель (обычно игрок)
    [SerializeField] private float sensitivity = 2f; // Чувствительность мыши
    [SerializeField] private float distance = 5f; // Расстояние от цели
    [SerializeField] private float height = 2f; // Высота над целью

    private float currentX = 0f;
    private float currentY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Получаем ввод с мыши
        currentX += Input.GetAxis("Mouse X") * sensitivity;
        currentY -= Input.GetAxis("Mouse Y") * sensitivity;

        // Ограничиваем вертикальное вращение
        currentY = Mathf.Clamp(currentY, -90f, 90f);

        // Поворот игрока вместе с камерой
        target.rotation = Quaternion.Euler(0, currentX, 0);
    }

    void LateUpdate()
    {
        // Вычисляем позицию камеры
        Vector3 dir = new Vector3(0, height, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 position = target.position + rotation * dir;

        // Устанавливаем позицию камеры
        transform.position = position;
        transform.LookAt(target);
    }
}
