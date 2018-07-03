using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01Examples
{
    public class Move : MonoBehaviour
    {

        public float speed = 1;
        public float amount = 1;
        public float offset = 0;

        void Start()
        {

        }

        void Update()
        {
            transform.localPosition = new Vector3(0, Mathf.Sin(offset+Time.time*speed)*amount, 0);
        }
    }
}