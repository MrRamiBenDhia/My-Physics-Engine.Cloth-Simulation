using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalForces : MonoBehaviour
{

    public Vector3 velocity = Vector3.zero;
    public float gravity = 9.81f;
    public float mass = 0.001f;
    public float damping = 0.88f;

    void FixedUpdate()
    {
        applyGravity();
    }
    void applyGravity()
    {
        Vector3 gravityForce = new Vector3(0f, -mass * gravity, 0f);

        // gravityForce *= damping;
        velocity += gravityForce * Time.deltaTime / mass;
        
        //** viscouse damping 
        velocity *= damping;
        
        //transform.position += velocity * Time.deltaTime;
    }
}
