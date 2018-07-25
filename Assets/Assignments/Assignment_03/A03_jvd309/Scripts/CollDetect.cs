using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jvd309
{
    public class CollDetect : MonoBehaviour
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
		private void OnTriggerEnter(Collider other)
		{
            if (grabbed)
            {  // now drop it
                transform.parent = null;  // release the object
                grabbed = false;
                myRb.isKinematic = false;  //    .useGravity = true;
                strobe.trigger = false;
                if (downPointer != null)
                    downPointer.DontDraw();
            }
		}
        private void OnTriggerStay(Collider other)
        {
            Debug.Log("Object is within trigger");
        }
        private void OnTriggerExit(Collider other)
        {
            transform.parent = Camera.main.transform;  // attach object to camera
            grabbed = true;
            strobe.trigger = true;   // turn on color strobe so we know we have it
            myRb.isKinematic = true; //  .useGravity = false;
        }


	}
}
