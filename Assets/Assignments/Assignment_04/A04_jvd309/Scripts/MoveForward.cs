using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jvd309
{
    public class MoveForward : MonoBehaviour
    {

        public float speed;

        public bool easingMovement = false;

        private bool isMoving = false;
        private float currentSpeed = 0.0f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetMouseButton(0))
            {
                isMoving = true;

                if (easingMovement)
                {
                    // accelerate to speed
                    currentSpeed = Mathf.Lerp(currentSpeed, speed, Time.deltaTime);   //currentSpeed + (.01f * speed);
                    Vector3 forward = Camera.main.transform.forward;
                    forward.y = 0;
                    transform.Translate(forward * currentSpeed * Time.deltaTime);

                }
                else
                {
                    Vector3 forward = Camera.main.transform.forward;
                    forward.y = 0;
<<<<<<< HEAD
                    transform.Translate(forward / speed * Time.deltaTime);
=======
                    transform.Translate(forward * speed * Time.deltaTime);
>>>>>>> bd5777b329ae63e28eaeb8959c27e8c3583a0852
                }
            }
            else if (isMoving && easingMovement)
            {
                // decelerate
            }

        }
    }
} 
