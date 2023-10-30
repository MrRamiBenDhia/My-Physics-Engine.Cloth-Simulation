using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target; // The object you want to keep in view.
    public float zoomSpeed = 5.0f;
    public float minZoomDistance = 5.0f;
    public float maxZoomDistance = 20.0f;
    public float rotationSpeed = 2.0f;
    public float panSpeed = 0.1f;

    private float distance;
    private Vector3 targetPosition;
    private Vector2 rotation = new Vector2(45, 45); // Initial rotation angles.

    private void Start()
    {
        // Initialize camera position and rotation.
        distance = Vector3.Distance(transform.position, target.position);
        targetPosition = target.position;
    }

    private void Update()
    {
        // Zoom with the scroll wheel.
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        distance -= scrollInput * zoomSpeed;
        distance = Mathf.Clamp(distance, minZoomDistance, maxZoomDistance);

        // Rotate the camera around the target.
        if (Input.GetMouseButton(0)) // Left mouse button to rotate.
        {
            rotation.x += Input.GetAxis("Mouse X") * rotationSpeed;
            rotation.y -= Input.GetAxis("Mouse Y") * rotationSpeed;

            // Clamp the vertical rotation to avoid flipping the camera.
            rotation.y = Mathf.Clamp(rotation.y, -80, 80);
        }

        // Pan the camera while keeping the object in view.
        if (Input.GetMouseButton(1)) // Right mouse button to pan.
        {
            float horizontalInput = Input.GetAxis("Mouse X");
            float verticalInput = Input.GetAxis("Mouse Y");

            Vector3 pan = new Vector3(horizontalInput, 0, verticalInput) * panSpeed;
            targetPosition += pan;
        }

        // Update the camera position and look at the target.
        Quaternion rotationQuaternion = Quaternion.Euler(rotation.y, rotation.x, 0);
        Vector3 dir = rotationQuaternion * Vector3.back;
        Vector3 newPos = targetPosition + dir * distance;
        transform.position = newPos;
        transform.LookAt(targetPosition);
    }
}
