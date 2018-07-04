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

        private Collider _collider;

		private void Start()
		{
            _collider = GetComponent<Collider>();

		}

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            PlayerController.Instance.MoveToPosition(transform.position, RequiredMovingTime);
            Debug.Log(_collider);
        }


		private void OnTriggerEnter(Collider other)
		{
            Debug.Log("HERE2");
            //Disable the collision detection on this collider when the camera is inside of it, so the casting ray won't be blocked by it.
            if (other.CompareTag("MainCamera")) {
                _collider.isTrigger = true;
            }
		}

		private void OnTriggerExit(Collider other)
		{
            //Re-enable the collision detection when camera exits the collider
            Debug.Log("HERE3");
            if (other.CompareTag("MainCamera"))
            {
                _collider.isTrigger = false;
            }
		}
	}
}
