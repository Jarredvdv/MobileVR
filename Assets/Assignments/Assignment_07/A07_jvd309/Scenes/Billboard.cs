using UnityEngine;
using System.Collections;

namespace jvd309
{
    public class Billboard : MonoBehaviour
    {

        void Update()
        {
            transform.LookAt(Camera.main.transform);
        }
    }
}