using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace jvd309
{
    public class SmoothMovement : MonoBehaviour
    {
        public static float curSpeed = 0;
        public float maxSpeed = 10;
        public float accelTime = 10;

        // Use this for initialization
        void Start()
        {
        }


        void Update()
        {
            if (Input.GetMouseButton(0) && (curSpeed < maxSpeed)) //If mouse is clicked, we increase the current speed
            {
                curSpeed = curSpeed + accelTime * Time.deltaTime;

            }
            else if (Input.GetMouseButtonUp(0) && (curSpeed > -maxSpeed)) //If mouse is let go, we decrease the current speed
            {
                curSpeed = curSpeed - accelTime * Time.deltaTime;
            }
            else //Otherwise, we gradually increase/decrease speed according to input
            {
                if (curSpeed > accelTime * Time.deltaTime) 
                {
                    curSpeed = curSpeed - accelTime * Time.deltaTime;
                }
                else if (curSpeed < -accelTime * Time.deltaTime)
                {
                    curSpeed = curSpeed + accelTime * Time.deltaTime;
                }
                else
                {
                    curSpeed = 0;
                }
            }

            //Once we've calculated what happens to the players speed we apply it to the forward direction
            Vector3 forward = Camera.main.transform.forward;
            forward.y = 0;
            transform.Translate(forward * curSpeed * Time.deltaTime);
        }
    }
}
