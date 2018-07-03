using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02Examples
{
    [ExecuteInEditMode]
    public class Raycast : MonoBehaviour
    {
        GameObject hitObject;
        public Material white;
        public Material red;
        public DrawLaser drawLaser;

        void Update()
        {

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                hitObject = hit.transform.gameObject;
                hitObject.GetComponent<MeshRenderer>().material.color = Color.red;
                drawLaser.DrawLine(transform.position, hit.point);
                Debug.Log("HIT");
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                if (hitObject != null)
                    hitObject.GetComponent<MeshRenderer>().material.color = Color.white;
                drawLaser.DontDraw();
                Debug.Log("MISS");
            }
        }
    }
}