<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

>>>>>>> bd5777b329ae63e28eaeb8959c27e8c3583a0852
namespace jvd309
{
    public class PlayerController : MonoBehaviour
    {
<<<<<<< HEAD
        public static PlayerController Instance;

        private void Awake()
        {
            //Singleton
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(this);
            }
        }

        public void Translate(Vector3 translation)
        {
            transform.Translate(translation, Space.World);
        }

        public void MoveToPosition(Vector3 des, float time)
        {
            StopAllCoroutines();
            des.y = transform.position.y;
            StartCoroutine(MoveToPositionGradually(des, time));
        }

        private IEnumerator MoveToPositionGradually(Vector3 des, float time)
        {
            float t = 0.0f;
            Vector3 initialPos = transform.position;
            while (t < time)
            {
                t += Time.smoothDeltaTime;
                transform.position = initialPos + (des - initialPos) * Mathf.Lerp(0.0f, 1.0f, t / time);
                yield return null;
            }
            transform.position = des;
        }
    }
}
=======
        public static PlayerController Instance;

		private void Awake()
		{
            //Singleton
            if (Instance == null) {
                Instance = this;
            } else if (Instance != this) {
                Destroy(this);
            }
		}

        public void Translate(Vector3 translation) {
            transform.Translate(translation, Space.World);
        }

        public void MoveToPosition(Vector3 des, float time)
        {
            StopAllCoroutines();
            des.y = transform.position.y;
            StartCoroutine(MoveToPositionGradually(des, time));
        }

        private IEnumerator MoveToPositionGradually(Vector3 des, float time) {
            float t = 0.0f;
            Vector3 initialPos = transform.position;
            while (t < time) {
                t += Time.smoothDeltaTime;
                transform.position = initialPos + (des - initialPos) * Mathf.Lerp(0.0f, 1.0f, t / time);
                yield return null;
            }
            transform.position = des;
        }
    }
}
>>>>>>> bd5777b329ae63e28eaeb8959c27e8c3583a0852
