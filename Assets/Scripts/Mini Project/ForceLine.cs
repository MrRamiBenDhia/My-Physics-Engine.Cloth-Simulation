using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceLine : MonoBehaviour
{
    [Range(0f,1f)]
    public float vectorX; 
    [Range(0f,1f)]
    public float vectorY; 
    [Range(0f,1f)]
    public float vectorZ;

    public Vector3 vectorF;

    public LineRenderer lineRenderer;

    //void Start()
    //{
    //    this.
    //    lineRenderer
    //}

    void updateVecF()
    {
        vectorF = new Vector3(vectorX, vectorY, vectorZ);
        lineRenderer.SetPosition(1, vectorF);
    }


    void Update()
    {
        updateVecF();
        //lineRenderer.SetPosition(1, transform.position + up * 0.5f);
    }
}
