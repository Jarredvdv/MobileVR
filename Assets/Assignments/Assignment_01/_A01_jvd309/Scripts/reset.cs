using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jvd309
{
    public class reset : MonoBehaviour
    {


        void Start()
        {

        }

        void FixedUpdate()
        {
            if (transform.position.y <= -20)
            {
                transform.position = new Vector3(10, 1, 0);
                transform.localScale += new Vector3(1, 0, 1);
                GameObject.Find("Player").GetComponent<Jump>().speed += 100;
            }

        }
    }
}