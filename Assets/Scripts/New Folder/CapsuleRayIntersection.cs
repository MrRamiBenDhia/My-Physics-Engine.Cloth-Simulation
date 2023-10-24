using UnityEngine;

public class CapsuleRayIntersection : MonoBehaviour
{
    void OnDrawGizmosSelected()
    {
        CapsuleCollider capsuleCollider = GetComponent<CapsuleCollider>();

        if (capsuleCollider == null)
        {
            Debug.LogError("Capsule Collider component not found.");
            return;
        }

        Vector3 capsuleCenter = capsuleCollider.center + transform.position;
        float capsuleHeight = capsuleCollider.height * transform.localScale.y;
        Vector3 capsuleAxis = Vector3.up * capsuleHeight;

        //float capsuleRadius = capsuleCollider.radius * Mathf.Max(transform.localScale.x, transform.localScale.z);

        //Gizmos.color = Color.yellow;
        //Gizmos.DrawWireSphere(capsuleCenter + Vector3.up * capsuleHeight * 0.5f, capsuleRadius);
        //Gizmos.DrawWireSphere(capsuleCenter - Vector3.up * capsuleHeight * 0.5f, capsuleRadius);

        //Gizmos.color = Color.yellow;
        //Gizmos.DrawWireSphere(capsuleCenter + capsuleAxis * 0.5f, capsuleRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(capsuleCenter + capsuleAxis * 0.5f, capsuleCenter - capsuleAxis * 0.5f);
    }

    void Update()
    {
        // Example ray: origin and direction
        Vector3 rayOrigin = new Vector3(0, 1, -1);
        Vector3 rayDirection = new Vector3(0, 0, 1);

        // Transform rayOrigin and rayDirection to local space of the capsule if needed
        rayOrigin = transform.InverseTransformPoint(rayOrigin);
        rayDirection = transform.InverseTransformDirection(rayDirection);

        RaycastHit hit;
        CapsuleCollider capsuleCollider = GetComponent<CapsuleCollider>();

        if (capsuleCollider.Raycast(new Ray(rayOrigin, rayDirection), out hit, Mathf.Infinity))
        {
            Vector3 intersectionPoint = transform.TransformPoint(hit.point);
            Debug.Log("Intersection Point: " + intersectionPoint);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(intersectionPoint, 0.1f);
        }
        else
        {
            Debug.Log("No intersection.");
        }
    }
}
