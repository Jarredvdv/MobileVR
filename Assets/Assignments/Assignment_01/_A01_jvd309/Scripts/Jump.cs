using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jvd309
{
    public class Jump : MonoBehaviour
    {
        Rigidbody rb;
        public bool isGrounded;
        public float speed;
        public float rotSpeed;
        public float jumpHeight;

        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            isGrounded = true;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            var y = Input.GetAxis("Horizontal") * rotSpeed;
            var z = Input.GetAxis("Vertical") * speed;
            transform.Translate(-z, 0, 0);
            transform.Rotate(0, y, 0);

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
            if (collision.gameObject.CompareTag("Jumpable"))
            {
                rb.AddForce(0, jumpHeight * 2, 0);
            }
        }
    }
}