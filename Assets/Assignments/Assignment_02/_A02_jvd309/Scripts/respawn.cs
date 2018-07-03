using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jvd309
{
    public class respawn : MonoBehaviour
    {
        Rigidbody rb;
        GameObject lava;
        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            lava = GameObject.FindWithTag("lava");
            if (lava.transform.position.y > rb.position.y)
            {
                GameObject.Find("Main Camera").transform.position = new Vector3(-15, 25, 10);
                rb.MovePosition(new Vector3(-29, 22, 44));
                rb.velocity = Vector3.zero;

            }

        }
    }

}
