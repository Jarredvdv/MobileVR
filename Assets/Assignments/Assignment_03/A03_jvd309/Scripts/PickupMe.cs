using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jvd309
{
    /***
     * PickupMe component allows user to select this object and
     * move it with their gaze
     ******/
    public class PickupMe : MonoBehaviour
    {
        public bool grabbed = false;  // have i been picked up, or not?
        Rigidbody myRb;
        StrobeSelected strobe;
        public DrawDownPointer downPointer;
        
        
        // Use this for initialization
        void Start()
        {
            
            myRb = GetComponent<Rigidbody>();
            strobe = GetComponent<StrobeSelected>();
            
        }
        
        // Update is called once per frame
        void Update()
        {
            
            if (transform.parent != null && transform.parent.position.y < 1.587) //value that intercepts plane
            {
                Vector3 cur_pos = transform.position;
                Vector3 cur_rot = transform.eulerAngles;
                cur_pos[1] = 0.5f;//Place cube above plane
                transform.position = cur_pos;
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z); //restrict rotation to feel more natural
                
                //Debug.Log(transform.parent.position.y);
                
                if (grabbed && (downPointer != null))
                {
                    downPointer.DrawLine(transform.position);
                }
            }
        }
        
        
        /*
         * PickupOrDrop
         * Handle the event when the user clicks the button while
         * gaze is on this object.  Toggle grabbed state.
         
         */
        public void PickupOrDrop()
        {
            if (grabbed)
            {  // now drop it
                transform.parent = null;  // release the object
                grabbed = false;
                myRb.isKinematic = false;  //    .useGravity = true;
                strobe.trigger = false;
                strobe.enabled = false;
                if (downPointer != null)
                downPointer.DontDraw();
            }
            else
            {   // pick it up:
                // make it move with gaze, keeping same distance from camer
                transform.parent = Camera.main.transform;  // attach object to camera
                grabbed = true;
                strobe.enabled = true;
                strobe.strobeColor = Color.red;
                strobe.trigger = true;   // turn on color strobe so we know we have it
                myRb.isKinematic = true; //  .useGravity = false;
            }
        }
    }
}