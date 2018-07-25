using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jvd309
{
    public class platformShoot : MonoBehaviour
    {
        public Rigidbody platform;
        public float speed;

        // Use this for initialization
        void buildPlatform()
        {
            Rigidbody newPlatform = (Rigidbody)Instantiate(platform, transform.position, transform.rotation);
            newPlatform.AddForce(newPlatform.transform.forward * speed);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                buildPlatform();
            }
        }
    }
}
