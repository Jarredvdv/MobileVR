using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02Examples
{
    public class RaycastInput : MonoBehaviour
    {

        public GameObject explosion;

        void Update()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                Debug.Log(hit.transform.gameObject.name);
                if(Input.GetMouseButton(0)){
                    GameObject g = Instantiate(explosion, objectHit.position, Quaternion.identity);
                    Destroy(objectHit.gameObject);
                    Destroy(g, 1f);
                }
            }

        }
    }
}
