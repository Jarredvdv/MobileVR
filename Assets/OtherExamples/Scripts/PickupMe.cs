using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OtherExamples
{
    /***
     * PickupMe component allows user to select this object and 
     * move it with their gaze
     ******/
    public class PickupMe : MonoBehaviour
    {
        public bool dontGoBelowGround = true; 
        public bool grabbed = false;  // have i been picked up, or not?
        public bool inGaze = false;  // Am I under gaze reticle?
        public float grabAngle;  // What angle is gaze when cube is grabbed?

        Rigidbody myRb;
        StrobeSelected strobe;

        // Use this for initialization
        void Start()
        {
            myRb = GetComponent<Rigidbody>();
            strobe = GetComponent<StrobeSelected>();
        }

        float lastAngle = 0f;
        // Update is called once per frame
        void Update()
        {
            // This code prevents the cube from passing through the ground plane, 
            // while still moving with the player, and returning it to the center of the gaze
            // when the player lifts their gaze above the ground
            if (grabbed)
            {
                float f_AngleBetween = Vector3.Angle(Vector3.up, Camera.main.transform.forward); // Returns an angle between 0 and 180
                f_AngleBetween -= 90f;  // will be >0 if below horizontal; and <0 if above

                Debug.Log("angle below horizon: "+f_AngleBetween);
                float yOnGround = transform.localScale.y / 2;  // y for center of object when it is on ground

                if (yOnGround - transform.position.y > .001f)
                {
                    Debug.Log("Keeping above ground: y should be " + yOnGround + " y is " + transform.position.y);
                    Vector3 pos = transform.position;
                    pos.y = yOnGround;
                    transform.position = pos;
                } else if (f_AngleBetween - grabAngle > 0.01 && f_AngleBetween < lastAngle){
                    // player's gaze is returning towards the object where it rests on ground, so 
                    //  keep object there until gaze meets it
                    Vector3 pos = transform.position;
                    pos.y = yOnGround;
                    transform.position = pos;                   
                }
                lastAngle = f_AngleBetween;
            }
        }

        /*
         * PickupOrDrop
         * Handle the event when the user clicks the button while 
         * gaze is on this object.  Toggle grabbed state.
         */
        public void PickupOrDrop()
        {
            Debug.Log("PickupOrDrop");
            if (grabbed)
            {  // now drop it
                transform.parent = null;  // release the object
                grabbed = false;
                myRb.isKinematic = false;  //    .useGravity = true;
                strobe.trigger = false;
                grabAngle = 0f;
            }
            else
            {   // pick it up:
                // make it move with gaze, keeping same distance from camera
                transform.parent = Camera.main.transform;  // attach object to camera

                // record vertical gaze angle of the camera at time it is grabbed,
                // so if gaze diverges from object (e.g. if gaze goes below ground while object
                // does not) then we can know when gaze has returned to the object
                grabAngle = Vector3.Angle(Vector3.up, Camera.main.transform.forward) - 90; // Returns an angle between 0 and 180
                Debug.Log(grabAngle); // is >0 if gaze is below horizon

                grabbed = true;
                strobe.trigger = true;   // turn on color strobe so we know we have it
                myRb.isKinematic = true; //  .useGravity = false;

            }
        }

        // when player gaze is on this object, register PickupOrDrop as handler for doubleclick
        public void SetInGaze(bool isin) {
            inGaze = isin;
            if (inGaze && !grabbed) {  // don't re-add the delegate if we're already holding
                MPSPlayerController.DoOnDoubleClick += PickupOrDrop;
            } else if (!grabbed) {  // don't relinquish control if still holding
                MPSPlayerController.DoOnDoubleClick -= PickupOrDrop;
            }
        }


    }
}
