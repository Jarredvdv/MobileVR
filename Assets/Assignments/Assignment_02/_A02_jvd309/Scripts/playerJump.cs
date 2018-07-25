using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace jvd309
{
    public class playerJump : MonoBehaviour
    {
        Rigidbody rb;
        public bool isGrounded;
        public float jumpHeight;

        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            isGrounded = true;
        }

        // Update is called once per frame
        void Update()
        {


            if (Input.GetKey(KeyCode.Space) && isGrounded == true) //if space bar is pressed (jump)
            {
                rb.AddForce(0, jumpHeight, 0);
                isGrounded = false;
                //transform.Translate(0, 0, 2); //move forward
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            isGrounded = true;

        }
    }
}