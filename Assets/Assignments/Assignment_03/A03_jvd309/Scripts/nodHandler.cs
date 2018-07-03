using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jvd309
{

    public class nodHandler : MonoBehaviour
    {
        private Vector3[] headAngle;
        private int index;
        private Vector3 startingAngle;
        public float scale; //scale used to measure degree of head movement
        public float distance;
        GameObject cube;

        // Use this for initialization
        void Start()
        {
            cube = GameObject.Find("Cube");
            Reset();
        }

        // Update is called once per frame
        void Update()
        {
            headAngle[index] = Camera.main.transform.eulerAngles;//creates array of 80 head angles
            index++;
            if (index == 80)//once filled check if yes or no
            {
                checkGesture();
                Reset();
            }
        }
        void checkGesture()
        {
            bool left = false;
            bool right = false;
            bool up = false;
            bool down = false;

            for (int i = 0; i < 80; i++)
            {
                if (headAngle[i].x < startingAngle.x - scale && !up) //head is moving up if i-th angle is less than starting angle & there is a change in direction
                {
                    up = true;
                }
                else if (headAngle[i].x > startingAngle.x + scale && !down) //head is down up if i-th angle is greater than starting angle
                {
                    down = true;
                }
                if (headAngle[i].y < startingAngle.y - scale && !left)//similar to above for y axis
                {
                    left = true;
                }
                else if (headAngle[i].y > startingAngle.y + scale && !right)
                {
                    right = true;
                }
            }
            if (left && right && !(up && down)) //Classification of head movements that also checks against false positives
            {
                Debug.Log("No");
                cube.transform.position = cube.transform.position + Camera.main.transform.forward * distance * Time.deltaTime; //adjusts position of cube further

            }

            if (up && down && !(left && right))
            {
                Debug.Log("Yes");
                cube.transform.position = cube.transform.position - Camera.main.transform.forward * distance * Time.deltaTime;//adjusts position of cube closer
            }
        }
        private void Reset()
        {
            headAngle = new Vector3[80]; //initialize array of 80 head angles
            index = 0;
            startingAngle = Camera.main.transform.eulerAngles;
        }
    }
}
