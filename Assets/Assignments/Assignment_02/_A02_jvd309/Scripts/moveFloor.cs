using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jvd309
{
    public class moveFloor : MonoBehaviour
    {
        public float speed;
        private Rigidbody rb;

        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();

            //rb.detectCollisions = false;
        }

        // Update is called once per frame
        void Update()
        {
            rb.MovePosition(transform.position + transform.up * speed);


        }
    }
}
