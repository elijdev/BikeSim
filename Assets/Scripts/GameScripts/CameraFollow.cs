using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 5f;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPosition = target.position;
            newPosition.z = -10;

            transform.position = newPosition;
            transform.position = Vector3.Lerp(transform.position, newPosition, followSpeed * Time.deltaTime);
        }
    }
}
