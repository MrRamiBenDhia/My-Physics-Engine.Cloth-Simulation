using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamyForcesVisuliser : MonoBehaviour
{
    public Color forceColor = Color.red;


    public IntegrationForces particule;

    DraggableBall draggable;
    public Vector3 force;
    public float forceScale = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("THIS "+ gameObject.name);

    }
    void Update()
    {
        //Debug.Log("velocity"+ particule.velocity);
        //particule.GetAllSpringOscillationVelocities().ForEach(spring =>
        //{
        //Debug.Log("Vector "+ spring.ToString());

        //});
    }
    void OnDrawGizmos()
    {
        // Draw the force vector
        Gizmos.color = forceColor;
        Gizmos.DrawRay(transform.position, force * forceScale);
    }
}
