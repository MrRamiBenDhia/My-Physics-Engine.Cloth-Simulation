using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntegrationForces : MonoBehaviour
{
    public float mass = 0.1f;  // equal mass for balls



    public Vector3 velocity = Vector3.zero;
    public float gravity = 9.81f;

    public float damping = 0.1f;

    void calculateViscosity(Vector3 velocity)
    {
        //** viscouse damping 
        velocity *= damping;

    }
    Vector3 calculateGravity()
    {
        Vector3 gravityForce = new Vector3(0f, -mass * gravity, 0f);
        //velocity += gravityForce * Time.deltaTime / mass;
        //transform.position += velocity * Time.deltaTime;
        return gravityForce;
    }
    public List<Vector3> GetAllSpringOscillationVelocities()
    {
        List<Vector3> velocities = new List<Vector3>();

        // Find all objects with the SpringOscillation script
        SpringOscillation[] springOscillations = GetComponents<SpringOscillation>();

        // Extract public velocity values and add them to the list
        foreach (SpringOscillation springOscillation in springOscillations)
        {
            velocities.Add(springOscillation.velocity);
        }

        return velocities;
    }
    Vector3 GetTotalOFSpringForces()
    {
        Vector3 total = Vector3.zero;
        List<Vector3> springFoces = GetAllSpringOscillationVelocities();
        //Debug.Log(springFoces.Count);
        foreach (Vector3 item in springFoces)
        {
            total += item;
        }
        // Debug.Log("~~ total~~");
        // Debug.Log(total);
        return total;
    }

    void Update()
    {
        float deltaTime = Time.deltaTime;


        Vector3 springForce = GetTotalOFSpringForces();
        Vector3 gravityForce = calculateGravity();
        //gravityForce = Vector3.zero;

        Vector3 dampingForce = -damping * velocity;
        Vector3 force = ( dampingForce + springForce * 15 + gravityForce /10);

        // Apply the force 
        Vector3 acceleration = force / mass;

        // Update velocity
        velocity += acceleration * deltaTime;

        // Update position based on velocity
        transform.position += velocity * deltaTime;

    }
}
