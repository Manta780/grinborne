using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // El personaje
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;   // Ajusta la distancia de la cámara al personaje

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
