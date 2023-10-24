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

    public Transform forcePosition1; // Position of the first force relative to the cube
    public Transform forcePosition2; // Position of the second force relative to the cube


    public Vector3 localForcePosition1; // Local position of the first force relative to the cube
    public Vector3 localForcePosition2; // Local position of the second force relative to the cube

    // Update is called once per frame
    void Update()
    {
        Vector3 worldForcePosition1 = cubeRigidbody.transform.TransformPoint(forcePosition1.localPosition);
        Vector3 worldForcePosition2 = cubeRigidbody.transform.TransformPoint(forcePosition2.localPosition);

        cubeRigidbody.AddForceAtPosition(forceLine1.vectorF.normalized * forceMagnitude1, worldForcePosition1);
        cubeRigidbody.AddForceAtPosition(forceLine2.vectorF.normalized * forceMagnitude2, worldForcePosition2);


    }
}
