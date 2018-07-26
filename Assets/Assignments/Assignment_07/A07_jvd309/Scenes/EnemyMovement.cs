using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

namespace jvd309
{
    [RequireComponent(typeof(CharacterController))]
    public class EnemyMovement : NetworkBehaviour
    {
        public float speed = 5;
        public float directionChangeInterval = 1;
        public float maxHeadingChange = 30;

        public GameObject bulletPrefab;
        public Transform bulletSpawn;

        CharacterController controller;
        float heading;

        [SyncVar]
        private Vector3 forward;

        [SyncVar]
        Vector3 targetRotation;



        void Awake()
        {
            controller = GetComponent<CharacterController>();

            // Set random initial rotation
            heading = Random.Range(0, 360);
            transform.eulerAngles = new Vector3(0, heading, 0);
            StartCoroutine(NewHeading());
        }

        void Update()
        {
            if (!isServer)
            {
                return;
            }

            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
            forward = transform.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * speed);
        }


        // Repeatedly calculates a new direction to move towards.
        IEnumerator NewHeading()
        {
            while (true)
            {
                NewHeadingRoutine();
                yield return new WaitForSeconds(Random.Range(directionChangeInterval - 1, directionChangeInterval + 1));
            }
        }

        // Calculates a new direction to move towards.

        void NewHeadingRoutine()
        {
            var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
            var ceil = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
            heading = Random.Range(floor, ceil);
            targetRotation = new Vector3(0, heading, 0);
        }

        void CmdFire()
        {
            // Create the Bullet from the Bullet Prefab
            var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

            // Spawn the bullet on the Clients
            //NetworkServer.Spawn(bullet);

            // Destroy the bullet after 2 seconds
            Destroy(bullet, 2.0f);
        }

        public override void OnStartServer()
        {
            InvokeRepeating("CmdFire", 5f, 2f);
        }
    }
}