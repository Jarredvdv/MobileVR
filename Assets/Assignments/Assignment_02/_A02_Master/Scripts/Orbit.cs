using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02Examples
{
    public class Orbit : MonoBehaviour
    {
        // These are set in the Inspector
        public Vector3 startDirection;

        public Transform centralBody;

        // These are set in Start
        float centralMass;
        Rigidbody rb;

        // Use this for initialization
        void Start()
        {
            // Get my rigidbody
            rb = GetComponent<Rigidbody>();
            // Give me an initial push 
            rb.AddForce(startDirection);

            // get the mass of the object I'm orbiting
            centralMass = centralBody.GetComponent<Rigidbody>().mass;
        }

        void FixedUpdate()
        {
            // Find the direction and distance to the object I'm orbiting
            Vector3 dir = centralBody.position - transform.position;
            // Get the distance squared
            float distSqr = dir.sqrMagnitude;
            // Get the direction (with magnitude of 1)
            dir.Normalize();

            // Now accelerate me towards the object I'm orbiting,
            // with a simulation of gravity
            rb.AddForce((rb.mass + centralMass)/distSqr * dir);
        }
    }
}