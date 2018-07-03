using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A03Examples { 
    public class DrawDownPointer : MonoBehaviour
    {

        LineRenderer lineRenderer;
        bool drawLine;

        void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            DontDraw();
        }

      
        public void DrawLine(Vector3 A)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(A,Vector3.down,out hitInfo)){
                drawLine = true;
                if (lineRenderer != null)
                {
                    lineRenderer.positionCount = 2;
                    lineRenderer.SetPosition(0, A);
                    lineRenderer.SetPosition(1, hitInfo.point);
                }
            }

        }

        public void DontDraw(){
            if(lineRenderer!=null)
                lineRenderer.positionCount = 0;
        }
    }
}