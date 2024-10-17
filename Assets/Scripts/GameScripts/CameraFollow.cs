using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 5f;
    public Vector3 offset = new Vector3(0, 2, -10);

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, Quaternion.identity.z) + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
