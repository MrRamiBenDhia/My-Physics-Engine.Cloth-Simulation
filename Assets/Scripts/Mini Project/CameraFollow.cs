using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The transform of the object to follow (your cube)
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Offset from the target object
    public float smoothSpeed = 0.125f; // Smoothing factor for the camera movement

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target.position); // Make the camera look at the target object
    }
}
