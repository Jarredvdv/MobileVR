using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace A03Examples
{
    [RequireComponent(typeof(Slider))]
    public class ScaleSliderController : MonoBehaviour
    {
        [HideInInspector]
        public Transform ControllingTransform;

        [Tooltip("The scale will change between 1 - range and 1 + range")]
        [Range(0.1f, 0.9f)]
        public float ScaleChangeRange = 0.5f;

        private Slider _slider;
        private Vector3 _initialLocalScale;

        public void ChangeObjectSize () {
            if (ControllingTransform != null)
            {
                ControllingTransform.localScale = _initialLocalScale * Mathf.Lerp(1.0f - ScaleChangeRange, 1.0f + ScaleChangeRange, _slider.value);
            }
        }

		private void Start()
		{
            _slider = GetComponent<Slider>();
		}

		private void OnEnable()
        {
            if (MenuCanvasController.Instance != null && MenuCanvasController.Instance.ControllingObject != null)
            {
                ControllingTransform = MenuCanvasController.Instance.ControllingObject.transform;
                _initialLocalScale = ControllingTransform.localScale;
                _slider.value = 0.5f;
            }
        }

        private void OnDisable()
        {
            ControllingTransform = null;
            _initialLocalScale = Vector3.one;
        }

    }
}
