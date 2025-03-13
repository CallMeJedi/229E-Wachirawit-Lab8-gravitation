using System;
using NUnit.Framework;
using System.Collections.Generic; //สร้างตู้
using UnityEngine;

public class GravityE : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.06674f;
    public static List<GravityE> gravityObjList; //สร้างตู้

    //Orbitting
    [SerializeField] bool planets = false;
    [SerializeField] int orbitSpeed = 1000;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        //สร้างตู้>>>
        if (gravityObjList == null) 
        {
            gravityObjList = new List<GravityE>();
        }
        gravityObjList.Add(this);
        //<<<สร้างตู้
        
        //Orbitting
        if (!planets)
        {
            rb.AddForce(Vector3.left * orbitSpeed);
        }
        //Orbitting
    }

    private void FixedUpdate()
    {
        //Attract
        foreach (var OBJPlanets in gravityObjList)
        {
            if (OBJPlanets != this)
            {
                Attract(OBJPlanets);
            }
        }
        //Attract
    }

    void Attract(GravityE other)
    {
        Rigidbody otherRb = other.rb;

        //find position between two objects
        Vector3 direction = rb.position - otherRb.position;
        float distance = direction.magnitude;
        float forceMagni = G * ((rb.mass * otherRb.mass) / Mathf.Pow(distance, 2));
        Vector3 FinalForce = forceMagni * direction.normalized;

        //Addforce
        otherRb.AddForce(FinalForce);


    }
}
