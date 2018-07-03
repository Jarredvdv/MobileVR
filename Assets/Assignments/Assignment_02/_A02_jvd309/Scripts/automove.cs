using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jvd309
{
    public class automove : MonoBehaviour
    {
        public float speed;
        private Rigidbody rb;

        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {

            //Vector3 movement = new Vector3(speed, 0, 0);

            rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);


        }
    }
}