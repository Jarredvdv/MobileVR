using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jvd309
{
    public class freezePlatform : MonoBehaviour
    {
        Rigidbody rb;
        // Use this for initialization
        void OnCollisionEnter(Collision collision)
        {
            rb.isKinematic = true;
        }
    }
}
