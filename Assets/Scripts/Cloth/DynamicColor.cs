using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicColor : MonoBehaviour
{
    public Material dynamiqueMaterial;


    //new material instance
    Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = new Material(dynamiqueMaterial);
        gameObject.GetComponent<Renderer>().material = material;

    }

    public void applyVelocityColor(Vector3 velocity)
    {
        
        float speed = velocity.magnitude;
        float maxSpeed = 1f;
        float normalizedSpeed = Mathf.Clamp(speed / maxSpeed, 0f, 1f);

        // Map the normalized speed to a color
        Color color = new Color(normalizedSpeed, 0, 1 - normalizedSpeed);

        material.color = color;
        // Apply the new material to the object
        //renderer.material = material;
    }
}
