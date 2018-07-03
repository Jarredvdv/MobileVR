using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jvd309
{
    public class Goal : MonoBehaviour
    {
        public GameObject goal;
        public Vector3 currentPos;

        // Use this for initialization
        void Start()
        {
            goal = GameObject.FindWithTag("Goal");
        }

        // Update is called once per frame
        void FixedUpdate()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Goal"))
            {
                transform.position = new Vector3(10, 1, 0);
                currentPos = goal.transform.position;
                currentPos.x -= 10;
                goal.transform.position = currentPos;
            }
        }
    }
}