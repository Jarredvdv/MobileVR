using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jvd309
{
    /***
     * PickupMe component allows user to select this object and 
     * move it with their gaze
     ******/
    public class rotateMe : MonoBehaviour
    {
        public bool grabbed = false;  // have i been picked up, or not?
        Rigidbody myRb;
        StrobeSelected strobe;
        public DrawDownPointer downPointer;

        Vector3 starting_pos;
        public float rot_speed;

        rotateMe RotateMe;
        MeshRenderer meshRenderer;
        Color initialColor;

        // Use this for initialization
        public void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            initialColor = meshRenderer.material.color;
            myRb = GetComponent<Rigidbody>();
            strobe = GetComponent<StrobeSelected>();
            starting_pos = transform.position;
        }

        // Update is called once per frame
        public void Update()
        {
            if (transform.parent != null)
            {
                strobe.trigger = true;
                strobe.strobeColor = Color.blue; //how we know we're rotating

                starting_pos[1] = 2f;
                transform.position = starting_pos; //hold cube in air

                transform.eulerAngles = transform.parent.eulerAngles * rot_speed; //rotate cube based on head movement

                myRb.isKinematic = true;

            }

            if (grabbed && (downPointer != null))
            {
                downPointer.DrawLine(transform.position);
            }

        }

        /*
         * Repurposed PickupOrDrop
         * Handle the event when the user clicks the button while 
         * gaze is on this object.  Toggle grabbed state.
         */
        public void RotateOrDrop()
        {
            if (grabbed)
            {  // now drop it
                transform.parent = null;  // release the object
                grabbed = false;
                myRb.isKinematic = true;  //.useGravity = false;
                strobe.trigger = false;
                if (downPointer != null)
                    downPointer.DontDraw();
            }
            else
            {   // pick it up:
                strobe.enabled = true;
                // make it move with gaze, keeping same distance from camer
                transform.parent = Camera.main.transform;  // attach object to camera
                grabbed = true;
                strobe.trigger = true;   // turn on color strobe so we know we have it
                myRb.isKinematic = true; //  .useGravity = false;


            }
        }
    }
}
