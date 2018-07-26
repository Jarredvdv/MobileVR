using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OtherExamples
{
    public class MPSPlayerController : MonoBehaviour
    {
        public GameObject OneClickPrefab;
        public float walkSpeed = 1.0f;
        public GameObject hitObject;

        // use this to register an event on a specific gameobject for when we double-click
        // while looking at that object
        public delegate void ObjDoubleClickHandler();
        public static event ObjDoubleClickHandler DoOnDoubleClick;


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
            // pickup or drop
            DoOnDoubleClick();
        }

        private void LongPressingAction(Touch touch)
        {
            print("Long Pressing");
            Vector3 direction = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);
            transform.Translate( direction * walkSpeed * Time.deltaTime);
        }

    }
}