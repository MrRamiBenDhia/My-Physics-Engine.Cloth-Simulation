using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePush : MonoBehaviour
{
    public ForceLine forceLine1;
    public ForceLine forceLine2;


    public Rigidbody cubeRigidbody;

    public float forceMagnitude1; 

    public float forceMagnitude2; 

    public Transform forcePosition1; 
    public Transform forcePosition2;



    private Matrix4x4 translationMatrix; // Matrice de translation
    private Matrix4x4 rotationMatrix; // Matrice de rotation
    private Vector3 position;
    private Quaternion rotation;
    private Vector3 velocity; // Vitesse de translation
    private Vector3 angularVelocity; // Vitesse angulaire

    public Matrix4x4 inertiaMatrix; // Matrice d'inertie

    public float mass = 1.0f;
    public float translationSpeed = 5.0f;
    public float rotationSpeed = 45.0f;

    void Start()
    {
        // Initialisation des matrices d'état, de la position et de la vitesse
        translationMatrix = Matrix4x4.identity;
        rotationMatrix = Matrix4x4.identity;
        position = transform.position;
        rotation = transform.rotation;
        velocity = Vector3.zero;
        angularVelocity = Vector3.zero;
    }




    // Update is called once per frame
    void Update()
    {
        //** read local position relative to the cube
        Vector3 worldForcePosition1 = cubeRigidbody.transform.TransformPoint(forcePosition1.localPosition); 
        Vector3 worldForcePosition2 = cubeRigidbody.transform.TransformPoint(forcePosition2.localPosition);

        ////**applying the forces
        //cubeRigidbody.AddForceAtPosition(forceLine1.vectorF.normalized * forceMagnitude1, worldForcePosition1);
        //cubeRigidbody.AddForceAtPosition(forceLine2.vectorF.normalized * forceMagnitude2, worldForcePosition2);

        // Lire les vecteurs de force des deux lignes
        Vector3 translationForce = forceLine1.vectorF - forceLine2.vectorF;
        Vector3 rotationForce = forceLine1.vectorF - forceLine2.vectorF;

        // Mettre à jour les matrices d'état de translation et rotation en fonction des forces
        Matrix4x4 deltaTranslation = Matrix4x4.Translate(translationForce * translationSpeed * Time.deltaTime);

        Matrix4x4 deltaRotation = Matrix4x4.Rotate(Quaternion.Euler(rotationForce * rotationSpeed * Time.deltaTime));

        translationMatrix = deltaTranslation * translationMatrix;
        rotationMatrix = deltaRotation * rotationMatrix;

        // Appliquer les matrices d'état à la position et à la rotation
        position = translationMatrix.MultiplyPoint(Vector3.zero);
        rotation = (rotationMatrix * Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Vector3.one)).rotation;

        Vector3 force = translationForce;
        Vector3 torque = rotationForce;

        Vector3 acceleration = force / mass;
        Vector3 angularAcceleration = inertiaMatrix.inverse.MultiplyVector(torque);

        velocity += acceleration * Time.deltaTime;
        angularVelocity += angularAcceleration * Time.deltaTime;

        // Mettre à jour la position et la rotation de l'objet
        transform.position = position;
        transform.rotation = rotation;
    }
}
