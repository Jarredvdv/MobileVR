using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jvd309
{
    public class MovingForward : MonoBehaviour
    {
        public float targetVel;
        float curVel;
        public float accelTime;
        Vector3 previous;
        bool isMoving;
        public bool easingMovement;
        // Use this for initialization
        void Start()
        {
            isMoving = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                isMoving = true;

                if (easingMovement)
                {
                    curVel = Mathf.Lerp(curVel, targetVel, Time.deltaTime * accelTime);
                    Vector3 forward = Camera.main.transform.forward;
                    forward.y = 0;
                    transform.Translate(forward * curVel * Time.deltaTime);
                }
                else
                {
                    Vector3 forward = Camera.main.transform.forward;
                    forward.y = 0;
                    transform.Translate(forward * targetVel * Time.deltaTime);
                }

            }
            else if (isMoving)
            {
                isMoving = false;
                curVel = Mathf.Lerp(curVel, 0, Time.deltaTime * accelTime);
                transform.Translate(Camera.main.transform.forward * curVel * Time.deltaTime);
            }

        }
    }
}
