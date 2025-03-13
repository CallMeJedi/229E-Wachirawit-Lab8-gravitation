using System;
using UnityEngine;

public class GravityE : MonoBehaviour
{
    Rigidbody rb;
    private const float G = 0.00674f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Attract(GravityE other)
    {
        Rigidbody otherRb = other.rb;

        //find position between two objects
        Vector3 direction = rb.position - otherRb.position;
        float distance = direction.magnitude;
        float forceMagni = G * ((rb.mass * otherRb.mass) / Mathf.Pow(distance, 2));
        vector3 FinalForce = forceMagni * direction.normalized;

        //Addforce
        otherRb.AddForce(FinalForce);


    }
}
