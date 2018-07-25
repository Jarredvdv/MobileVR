using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A03Examples
{
    /***
    * GazeAtMeNoCoroutine
    * Implements basic timer selection of object.
    * Does same as GazeAtMe, but checks for gaze continuously in Update, 
    * instead of using Coroutine.
    ****/
    public class GazeAtMeNoCoroutine : MonoBehaviour
    {
        Rigidbody myRb;
        public Color selectColor = Color.red;
        public float popTime = 2.0f;

        Color initialColor;
        float counter = 0;
        MeshRenderer meshRenderer;
        IEnumerator coroutine;

        bool gazeIn = false; // Set on gaze enter, clear on gaze exit

        void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            initialColor = meshRenderer.material.color;
            myRb = GetComponent<Rigidbody>();

        }


        public void Update()
        {
            if (gazeIn)
            {
                // fade color towards selectColor until popTime has elapsed

                Debug.Log("hi");
                counter += Time.deltaTime;
                meshRenderer.material.color = Color.Lerp(initialColor, selectColor, counter / popTime);

                if (counter > popTime)
                {                  // Then pop cube.
                    myRb.AddForce(Vector3.up * 300 + Random.insideUnitSphere * .25f);
                    myRb.AddTorque(Random.insideUnitSphere * 10);
                    Reset();

                }
            }
        }

        /***
        * GazeAndPop
        * triggered when gaze intersects with collider
        * **/
        public void GazeAndPop()
        {
            counter = 0;
            gazeIn = true;
        }

        /***
        * Reset
        * Called when gaze stops intersecting collider
        * Resets color and stops timer coroutine
        * **/
		public void Reset()
		{
            meshRenderer.material.color = initialColor;
            counter = 0;
            gazeIn = false;
		}
	}
}
