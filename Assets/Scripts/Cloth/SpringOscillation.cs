using UnityEngine;

public class SpringOscillation : MonoBehaviour
{
    public Transform connectedObject;  // The connected sphere
    public float springConstant = 200f;
    public float equilibriumLength = 2f;
    public float mass = 1f;  // equal mass for balls
    public Vector3 velocity = Vector3.zero;
    public Vector3 forceSpring= Vector3.zero;

    void Start()
    {
        equilibriumLength = Vector3.Distance(connectedObject.position, transform.position);
    }

    public Vector3 getNormal()
    {
        Vector3 point1 = transform.position - transform.position;
        Vector3 point2 = connectedObject.position - transform.position;
        Vector3 normal = Vector3.Cross(point1, point2).normalized;
        return normal;
    }

    public Vector3 HookesLaw()
    {
        // Calculate the displacement between the connected object and this object
        Vector3 displacement = connectedObject.position - transform.position;

        // Calculate the force based on Hooke's Law (F = -k * x)
        float forceMagnitude = springConstant * (displacement.magnitude - equilibriumLength);
        Vector3 force = forceMagnitude * displacement.normalized;

        // Apply the force 
        Vector3 acceleration = force / mass;

        // Update velocity
        float deltaTime = Time.deltaTime;
        velocity = acceleration * deltaTime;
        return force;
    }

    void FixedUpdate()
    {
        forceSpring = HookesLaw();
        // Update position based on velocity
        //transform.position += velocity;

        //// Apply the opposite force for bidirectional attraction
        //connectedObject.position -= velocity;
    }
}
