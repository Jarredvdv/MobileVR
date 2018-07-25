using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace jvd309
{
    public class GenerateTerrain : MonoBehaviour
    {

        int heightScale = 5;
        float detailScale = 5.0f; //Values that determines how perlin noise is used to generate terrain heights/detail
        List<GameObject> myTrees = new List<GameObject>();

        // Use this for initialization
        void Start()
        {
            Mesh mesh = this.GetComponent<MeshFilter>().mesh;
            Vector3[] vertices = mesh.vertices;

            //We loop through each vertex of a plane and use perlin noise to assign randomly generated values to the position of each vertex
            for (int v = 0; v < vertices.Length; v++)
            {
                vertices[v].y = Mathf.PerlinNoise((vertices[v].x + this.transform.position.x) / detailScale,
                                                  (vertices[v].z + this.transform.position.z) / detailScale) * heightScale;

                if (vertices[v].y > 2 && Mathf.PerlinNoise((vertices[v].x + 5) / 10, (vertices[v].z + 5) / 10) * 10 > 4.6) //We use perlin noise again to naturally distribute trees above a certain height
                {
                    GameObject newTree = TreePool.getTree(); //If this is a suitable to place a tree, we check if there exists an inactive tree at this location
                    if (newTree != null)
                    {
                        //Now that we have an active tree, we must place it above where the current vertex of the plane is
                        Vector3 treePos = new Vector3(vertices[v].x + this.transform.position.x,
                                                      vertices[v].y,
                                                      vertices[v].z + this.transform.position.z);
                        newTree.transform.position = treePos;
                        newTree.SetActive(true);//We must also remember to make this tree active
                        myTrees.Add(newTree);//We also add the tree to a list of active trees to ensure we dont overload the server with too many trees

                    }
                }

            }

            mesh.vertices = vertices;//Now that we've tweaked each plane's vertex we must apply this to the mesh itself
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            this.gameObject.AddComponent<MeshCollider>();

        }

        void OnDestroy()
        {
            for (int i = 0; i < myTrees.Count; i++)
            {
                if (myTrees[i] != null)
                    myTrees[i].SetActive(false);
            }
            myTrees.Clear();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}