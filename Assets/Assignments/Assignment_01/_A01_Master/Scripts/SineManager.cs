using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01Examples
{
    public class SineManager : MonoBehaviour
    {
        public GameObject SNAKE;
        public GameObject Ball;
        public int amount;

        void Start()
        {
            
            //GameObject SNAKE = new GameObject();
            //SNAKE.name = "SNAKE";


            for (int i = 0; i < amount; i++)
            {
                GameObject ballParent = new GameObject();
                ballParent.transform.parent = SNAKE.transform;
                ballParent.name = "ballParent_" + i;
                GameObject ball = Instantiate(Ball,ballParent.transform);
                ballParent.transform.position = new Vector3(0, 0, -i);
                ball.GetComponent<Move>().offset = i;
            }
        }

        void Update()
        {

        }
    }
}
