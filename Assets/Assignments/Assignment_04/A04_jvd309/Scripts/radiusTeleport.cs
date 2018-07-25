using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jvd309
{
    public class radiusTeleport : MonoBehaviour
    {
        RaycastHit hit;
        float hitDistance;
        private Collider _collider;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //Debug raycast
            Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward) * 10;

            if (Physics.Raycast(Camera.main.transform.position, forward, out hit)) //Check if there is a raycast hit in the forward direction
            {
                hitDistance = hit.distance;//Stores the length of the raycast when there is a hit

                if (Input.GetMouseButtonDown(0) && hitDistance < 10f && hit.collider.tag == "Floor")//if the length of the raycast hit is less than 10, we can teleport the player to that position
                {
                  
                    Vector3 forwardPos = hit.point;
                    forwardPos.y = 0;
                    transform.Translate(forwardPos);
                }

            }
        }
    }
}