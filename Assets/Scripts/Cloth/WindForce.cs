using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WindForce : MonoBehaviour
{

    [SerializeField]
    float _windforce = 10f;

    public Vector3 windForce;

    private void OnTriggerStay(Collider other)
    {
        windForce = transform.up * _windforce; 
        var hit = other.gameObject;

        if (hit != null)
        {
            IntegrationForces partForces = other.GetComponent<IntegrationForces>();
            partForces.isUnderWind = true;
        }


    }
    private void OnTriggerExit(Collider other)
    {
        var hit = other.gameObject;

        if (hit != null)
        {
            IntegrationForces partForces = other.GetComponent<IntegrationForces>();
            partForces.isUnderWind = false;
        }
    }
}

