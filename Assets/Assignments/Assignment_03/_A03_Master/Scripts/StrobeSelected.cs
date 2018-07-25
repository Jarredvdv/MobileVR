using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A03Examples
{
    /***
     * StrobeSelected component causes object color to continuously
     * fade to strobeColor and back, while trigger is true.
     * Can be used to indicate object has been selected.
     * ***/
    public class StrobeSelected : MonoBehaviour
    {

        public bool trigger = false;
        public Color strobeColor = Color.red;  // target color for fading
        public float strobeSpeed = 12;

        Color initColor;
        bool prevTrigger = false;

        void Start()
        {
            // save the initial color of the object
            initColor = this.GetComponent<MeshRenderer>().material.color;
        }

        void Update()
        {

            HandleTrigger();
        }

        void HandleTrigger()
        {

            if (trigger)
            {
                Strobe();
            }

            if (!trigger && prevTrigger)
            {  // if object had been strobing and is now released, restore initial color
                this.GetComponent<MeshRenderer>().material.color = initColor;
            }

            prevTrigger = trigger;

        }

        void Strobe()
        {  // fade color back and forth between initial color and strobe color target
            this.GetComponent<MeshRenderer>().material.color =
                Color.Lerp(initColor, strobeColor, (Mathf.Sin(Time.time * strobeSpeed) + 1) * .5f);

        }
    }
}
