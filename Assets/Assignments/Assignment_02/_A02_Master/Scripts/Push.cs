using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02Examples
{
    public class Push : MonoBehaviour
    {

        public float speed = 10.0f;

        Rigidbody rb;

        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();

            // Give this object one push, at the start of the game:
            // this will make the object move with a constant speed, forever
            rb.AddForce(Vector3.right * speed);

        }

        void FixedUpdate()
        {
            // Keep pushing for every physics update: this
            //  will continuously accelerate the object
            rb.AddForce(Vector3.right * speed);
        }
    }
}