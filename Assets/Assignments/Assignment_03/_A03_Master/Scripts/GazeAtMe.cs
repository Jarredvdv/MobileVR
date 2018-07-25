using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A03Examples
{
    /***
    * GazeAtMe
    * Implements basic timer selection of object.
    * ***/
    public class GazeAtMe : MonoBehaviour
    {
        Rigidbody myRb;
        public Color selectColor = Color.red; // will fade to this color as time elapses
        public float popTime = 2.0f;  // timer duration

        Color initialColor;
        float counter = 0;
        MeshRenderer meshRenderer;
        IEnumerator coroutine;

        void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            initialColor = meshRenderer.material.color;
            myRb = GetComponent<Rigidbody>();

        }

        /***
         * GazeAndPop
         * triggered when gaze intersects with collider
         * **/
        public void GazeAndPop()
        {
            coroutine = Gaze();
            StartCoroutine(coroutine);
        }

		/***
		 * Gaze
		 * Coroutine, fades color towards selectColor until popTime has elapsed
		 * Then pops cube.
		 * **/
		IEnumerator Gaze(){
            counter = 0;
            while (counter < popTime)
            {
                Debug.Log("hi");
                counter += Time.deltaTime;
                meshRenderer.material.color = Color.Lerp(initialColor, selectColor, counter / popTime);
                yield return null;
            }
            myRb.AddForce(Vector3.up * 300 + Random.insideUnitSphere * .25f);
            myRb.AddTorque(Random.insideUnitSphere * 10);
            Reset();
        }

        /***
         * Reset
         * Called when gaze stops intersecting collider
         * Resets color and stops timer coroutine
         * **/
		public void Reset()
		{
            StopCoroutine(coroutine);
            meshRenderer.material.color = initialColor;
            counter = 0;
		}
	}
}
