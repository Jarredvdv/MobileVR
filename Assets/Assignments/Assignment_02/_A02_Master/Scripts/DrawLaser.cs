using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02Examples { 
    public class DrawLaser : MonoBehaviour
    {

        LineRenderer lineRenderer;
        bool drawLine;

        void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

      
        public void DrawLine(Vector3 A, Vector3 B){
            drawLine = true;
            if (lineRenderer != null)
            {
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, A);
                lineRenderer.SetPosition(1, B);
            }
        }

        public void DontDraw(){
            if(lineRenderer!=null)
                lineRenderer.positionCount = 0;
        }
    }
}