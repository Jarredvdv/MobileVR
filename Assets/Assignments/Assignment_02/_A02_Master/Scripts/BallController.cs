using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02Examples
{
    /*****
     * BallController
     * Lets user push an object around using keyboard input
     * Based on the Unity Roll-A-Ball Tutorial
     *****/
    public class BallController : MonoBehaviour
    {
        // A multiplier to determine how strongly to push the ball
        //  with each key press
        public float speed = 10.0f;

        Rigidbody rb;

        // Use this for initialization
        void Start()
        {
            // Get my rigidbody
            rb = GetComponent<Rigidbody>();
        }

        // FixedUpdate is called once per physics update (a fixed timestep)
        void FixedUpdate()
        {
            // Check if any of the keys are pressed for the 
            // Horizontal or Vertical axes
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            // Use the input to compute a new force direction
            Vector3 dir = new Vector3(moveX, 0.0f, moveZ);

            // Push the ball in the direction specified
            rb.AddForce(dir * speed);
        }
    }
}