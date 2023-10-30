using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WindForce : MonoBehaviour
{

    [SerializeField]
    float _windforce = 10f;


    private void OnTriggerStay(Collider other)
    {
        var hit = other.gameObject;

        if (hit != null)
        {
            var rb = hit.GetComponent<Rigidbody>();
            var dir = transform.up;
            rb.AddForce(dir* _windforce);
        }
    }
}

