using UnityEngine;
using System.Collections;

namespace jvd309
{
    public class TreePool : MonoBehaviour
    {

        static int numTrees = 1000; //specifies max number of trees that can be loaded at once
        public GameObject treePrefab;
        static GameObject[] trees; //keeps track of all tree objects

        // Use this for initialization
        void Start()
        {

            trees = new GameObject[numTrees]; //creates array to hold all tree objects
            for (int i = 0; i < numTrees; i++)
            {
                trees[i] = (GameObject)Instantiate(treePrefab, Vector3.zero, Quaternion.identity);
                trees[i].SetActive(false); //We set all trees to inactive when the scene is started
            }

        }


        static public GameObject getTree() //Return a tree object if tree is inactive
        {
            for (int i = 0; i < numTrees; i++)
            {
                if (!trees[i].activeSelf)
                {
                    return trees[i];
                }
            }
            return null;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}