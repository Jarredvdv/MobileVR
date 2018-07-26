using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OtherExamples
{
    public class DemoPlayerController : PlayerController
    {
        public GameObject OneClickPrefab;
        public float walkSpeed = 1.0f;

        // Use this for initialization
        void Start()
        {
            TouchListener.OnSingleClick += SingleClickAction;
            TouchListener.OnDoubleClick += DoubleClickAction;
            TouchListener.OnLongPressing += LongPressingAction;
        }

        private void SingleClickAction(Touch touch)
        {
            print("Single Click");
            Instantiate(OneClickPrefab, transform.position + transform.forward, Quaternion.identity);
        }

        private void DoubleClickAction(Touch touch)
        {
            print("Double Click");
            Translate(Camera.main.transform.forward);
        }

        private void LongPressingAction(Touch touch)
        {
            print("Long Pressing");
            Translate(Camera.main.transform.forward * walkSpeed * Time.deltaTime);
        }

    }
}