using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace jvd309
{
    [RequireComponent(typeof(Collider))]
    public class MovingDestination : MonoBehaviour, IPointerClickHandler
    {
        [Tooltip("How long does the player need to get here")]
        public float RequiredMovingTime;
        RaycastHit hit;
        float hitDistance;
        private Collider _collider;
        Vector3 forward;
        GameObject player;

        public float MinDistance;

        private void Start()
        {

            player = GameObject.FindWithTag("Player");
            _collider = GetComponent<Collider>();

        }
        void Update()
        {
            //Debug raycast
            forward = Camera.main.transform.TransformDirection(Vector3.forward) * 10;
            if (Physics.Raycast(Camera.main.transform.position, forward, out hit))
            {
                hitDistance = hit.distance;
                print(hitDistance + " " + hit.collider.tag);
            }//Debug.DrawRay(Camera.main.transform.position, forward, Color.red);
        }


        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (hitDistance < MinDistance)
            {
                Vector3 forwardPos = hit.point;
                forwardPos.y = 10;
                player.transform.position = forwardPos;
                //PlayerController.Instance.MoveToPosition(forwardPos, RequiredMovingTime);
            }

        }


        private void OnTriggerEnter(Collider other)
        {
            //Disable the collision detection on this collider when the camera is inside of it, so the casting ray won't be blocked by it.
            if (other.CompareTag("MainCamera"))
            {
                _collider.isTrigger = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            //Re-enable the collision detection when camera exits the collider
            if (other.CompareTag("MainCamera"))
            {
                _collider.isTrigger = false;
            }
        }
    }
}
