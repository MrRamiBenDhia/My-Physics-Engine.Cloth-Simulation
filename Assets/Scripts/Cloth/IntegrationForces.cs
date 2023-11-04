using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntegrationForces : MonoBehaviour
{
    public float mass = 10f;  // equal mass for balls



    public Vector3 velocity = Vector3.zero;
    public float gravity = 9.81f;

    public float damping = 0.88f;

    public Vector3 force = Vector3.zero;
    public bool isUnderWind = false;

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
            velocities.Add(springOscillation.forceSpring);
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
            total -= item;
            
        }
        // Debug.Log("~~ total~~");
        // Debug.Log(total);
        return total;
    }

    void calculateForces()
    {
        Vector3 springForce = GetTotalOFSpringForces();
        Vector3 gravityForce = calculateGravity();
        //gravityForce = Vector3.zero;

        force = (springForce + gravityForce);

    }
    public void addWindForce()
    {
        Vector3 windForce = new Vector3(0,0, 10f);
        force += windForce/ 0.5f;
    }

    void Update()
    {
        float deltaTime = Time.deltaTime;

        calculateForces();
        if (isUnderWind)
        {
            addWindForce();
        }

        // Apply the force 
        Vector3 acceleration = force / mass;

        // Update velocity
        velocity = acceleration * deltaTime;

        //! Applying Damping
        velocity *= damping;

        //applyVelocityColor(velocity);
        // Update position based on velocity
        transform.position += velocity * deltaTime;

    }

    //void applyVelocityColor(Vector3 velocity)
    //{
    //    Material material = transform.GetComponent<Renderer>().material;
    //    float speed = velocity.magnitude;
    //    float maxSpeed = 10f; 
    //    float normalizedSpeed = Mathf.Clamp(speed / maxSpeed, 0f, 1f);

    //    // Map the normalized speed to a color
    //    Color color = new Color(normalizedSpeed, 0, 1 - normalizedSpeed);

    //    material.color = color;
    //}
}
