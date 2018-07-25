using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace jvd309
{
    public class modeHandler : MonoBehaviour
    {
        rotateMe RotateMe;
        PickupMe PickupMe;
        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        public void CheckMode(){
            //When the cube is clicked disable picking up of cube
            PickupMe = FindObjectOfType<PickupMe>();
            PickupMe.enabled = false;

            //Start rotate script and initialize new values
            RotateMe = FindObjectOfType<rotateMe>();
            RotateMe.enabled = true;
            RotateMe.Start();
            RotateMe.RotateOrDrop();
            RotateMe.Update();
        }
    }
}