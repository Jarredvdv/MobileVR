using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace jvd309
{
    public class Rotate : MonoBehaviour
    {

        // properties
        // Transform transform
        // GameObject gameObject
        public float speed = 10.0f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            //Debug.Log(transform.eulerAngles);

            // calculate rotation for each frame
            transform.Rotate(Vector3.up * Time.deltaTime * speed);
        }
    }
}