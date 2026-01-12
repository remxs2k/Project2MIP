using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (target != null)
        {
            // OLD WAY (Follows everything):
            // Vector3 desiredPosition = target.position + offset;

            // NEW WAY (Follows X only):
            // We use target.x, but we keep the camera's ORIGINAL y and z
            Vector3 desiredPosition = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z);

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}