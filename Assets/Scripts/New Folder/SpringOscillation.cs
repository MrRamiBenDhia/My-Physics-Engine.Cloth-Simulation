using UnityEngine;

public class SpringOscillation : MonoBehaviour
{
    public Transform connectedObject;  // The connected sphere
    public float springConstant = 2f;
    public float equilibriumLength = 2f;
    public float mass = 1f;  // assuming equal mass for both balls

    void Start()
    {
        equilibriumLength = Vector3.Distance(connectedObject.position, transform.position);
    }

    void Update()
    {
        // Calculate the displacement between the connected object and this object
        Vector3 displacement = connectedObject.position - transform.position;

        // Calculate the force based on Hooke's Law (F = -k * x)
        float forceMagnitude = springConstant * (displacement.magnitude - equilibriumLength);
        Vector3 force = forceMagnitude * displacement.normalized;

        // Apply the force to move the objects based on their mass
        Vector3 acceleration = force / mass;

        // Update velocity using the calculated acceleration
        float deltaTime = Time.deltaTime;
        Vector3 velocity = acceleration * deltaTime;

        // Update position based on velocity
        transform.position += velocity;

        // Apply the opposite force to the connected object to achieve bidirectional attraction
        connectedObject.position -= velocity * (mass / connectedObject.GetComponent<SpringOscillation>().mass);
    }
}
