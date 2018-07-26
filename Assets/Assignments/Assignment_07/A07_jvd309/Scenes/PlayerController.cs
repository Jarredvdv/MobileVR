using UnityEngine;
using UnityEngine.Networking;

namespace jvd309
{
    public class PlayerController : NetworkBehaviour
    {
        public GameObject bulletPrefab;
        public Transform bulletSpawn;
        public Transform cam_pos;
        private float nextActionTime = 0.0f;
        public float period = .5f;
        public Vector3 direction;
        public float maxSpeed = 5;
        public float accelTime = 10;
        private float curSpeed = 0;
        private bool isMoving;



        void Update()
        {
            if (!isLocalPlayer)
            {
                return;
            }


            if (Input.GetMouseButton(0) && (curSpeed < maxSpeed)) //If mouse is clicked, we increase the current speed
            {
                curSpeed = curSpeed + accelTime * Time.deltaTime;
                isMoving = true;

            }
            else if (Input.GetMouseButtonUp(0) && (curSpeed > -maxSpeed)) //If mouse is let go, we decrease the current speed
            {
                curSpeed = curSpeed - accelTime * Time.deltaTime;
            }
            else //Otherwise, we gradually increase/decrease speed according to input
            {
                if (curSpeed > accelTime * Time.deltaTime)
                {
                    curSpeed = curSpeed - accelTime * Time.deltaTime;
                }
                else if (curSpeed < -accelTime * Time.deltaTime)
                {
                    curSpeed = curSpeed + accelTime * Time.deltaTime;
                }
                else
                {
                    isMoving = false;
                    curSpeed = 0;
                }
            }
            if (isMoving)
            {

                direction = new Vector3(cam_pos.forward.x, 0, cam_pos.forward.z).normalized * Time.deltaTime;
                Quaternion rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
                transform.Translate(rotation * (direction * curSpeed));
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                if (Time.time > nextActionTime)
                {
                    nextActionTime += period;
                    CmdFire();
                }
            }

            // First we have to rotate the player based on the cardbaord headset
            Vector3 player_rotation = cam_pos.rotation.eulerAngles;
            player_rotation.x = 0;
            player_rotation.z = 0;
            transform.eulerAngles = player_rotation;


            // move the player according to input
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
            transform.Translate(0, 0, z);

            // move the camera to match the player's position
            Camera.main.transform.parent.position = transform.Find("Visor").position;
           }


        // This [Command] code is called on the Client …
        // … but it is run on the Server!
        [Command]
        void CmdFire()
        {
            // Create the Bullet from the Bullet Prefab
            var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10;

            // Spawn the bullet on the Clients
            NetworkServer.Spawn(bullet);

            // Destroy the bullet after 2 seconds
            Destroy(bullet, 2.0f);
        }

        public override void OnStartLocalPlayer()
        {
            GetComponent<Renderer>().material.color = Color.blue;

            cam_pos = Camera.main.transform;
            Camera.main.transform.parent.position = transform.Find("Visor").position;
        }



    }
}