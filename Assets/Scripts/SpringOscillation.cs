using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringOscillation : MonoBehaviour
{
    public Transform ball1;
    public Transform ball2;
    public float springConstant = 1f;
    public float equilibriumLength = 5f;
    public float mass = 1f; // assuming equal mass for both balls

    void Update()
    {
        // Calculate the displacement between the balls
        Vector3 displacement = ball2.position - ball1.position;

        // Calculate the force based on Hooke's Law (F = -k * x)
        float forceMagnitude = springConstant * (displacement.magnitude - equilibriumLength);
        Vector3 force = forceMagnitude * displacement.normalized;

        // Apply the force to move the balls based on their mass
        Vector3 acceleration = force / mass;

        // Update velocity using the calculated acceleration
        float deltaTime = Time.deltaTime;
        Vector3 velocity1 = acceleration * deltaTime;
        //Vector3 velocity2 = -acceleration * deltaTime;

        // Update positions based on velocities
        ball1.position += velocity1;
        //ball2.position += velocity2;
    }
}
