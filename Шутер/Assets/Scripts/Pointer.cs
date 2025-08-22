using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform Aim;
    public Camera PlayerCamera;
    public Transform PlayerBody;
    [SerializeField] private float rotationSpeed = 15f; // Скорость плавного поворота

    void LateUpdate()
    {
        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction);

        Plane plane = new Plane(new Vector3(0f, 0f, -1f), Vector3.zero);

        float distance;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);

        Aim.position = point;

        Vector3 toAim = Aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);

        if (PlayerBody != null)
        {
            Vector3 bodyLookDirection = toAim;
            bodyLookDirection.y = 0;

            if (bodyLookDirection != Vector3.zero)
            {
                // Рассчитываем текущий угол
                float currentAngle = Vector3.SignedAngle(Vector3.forward, -bodyLookDirection, Vector3.up);

                // Ограничиваем угол
                float clampedAngle = Mathf.Clamp(currentAngle, -30f, 30f);

                // Целевой поворот
                Quaternion targetRotation = Quaternion.LookRotation(Quaternion.Euler(0, clampedAngle, 0) * Vector3.forward);

                // Плавный поворот
                PlayerBody.rotation = Quaternion.Slerp(
                    PlayerBody.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime
                );
            }
        }
    }
}
