using UnityEngine;
using System.Collections;


namespace jvd309
{
    class Tile
    {
        public GameObject theTile;
        public float creationTime;

        public Tile(GameObject t, float ct)
        {
            theTile = t;
            creationTime = ct;
        }
    }


    public class GenerateInfinite : MonoBehaviour
    {

        public GameObject plane;
        public GameObject player;

        int planeSize = 10;
        int halfTilesX = 3;
        int halfTilesZ = 3;

        Vector3 startPos;

        Hashtable tiles = new Hashtable(); //We maintain a hashtable of tiles and their ID

        // Use this for initialization
        void Start()
        {
            //When scene is run we must generate an initial floor
            this.gameObject.transform.position = Vector3.zero;
            startPos = Vector3.zero;

            float updateTime = Time.realtimeSinceStartup;

            for (int x = -halfTilesX; x < halfTilesX; x++)
            {
                for (int z = -halfTilesZ; z < halfTilesZ; z++)
                {
                    Vector3 pos = new Vector3((x * planeSize + startPos.x),//We generate the position of each new plane that extends from the original plane
                                                0,
                                              (z * planeSize + startPos.z));
                    GameObject t = (GameObject)Instantiate(plane, pos, //Then we create the new plane and add it to the list of tiles as well as the tile ID
                                       Quaternion.identity);

                    string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                    t.name = tilename;
                    Tile tile = new Tile(t, updateTime);
                    tiles.Add(tilename, tile);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            //We must first calculate how far the player has moved since the last frame
            int xMove = (int)(player.transform.position.x - startPos.x);
            int zMove = (int)(player.transform.position.z - startPos.z);

            //If the player has moved more than the length of a single plane, we must create/destroy surrounding planes
            if (Mathf.Abs(xMove) >= planeSize || Mathf.Abs(zMove) >= planeSize)
            {
                float updateTime = Time.realtimeSinceStartup;
                int playerX = (int)(Mathf.Floor(player.transform.position.x / planeSize) * planeSize);
                int playerZ = (int)(Mathf.Floor(player.transform.position.z / planeSize) * planeSize);

                //Similar to before, we now generate a set of planes that encompass the players new position
                for (int x = -halfTilesX; x < halfTilesX; x++)
                {
                    for (int z = -halfTilesZ; z < halfTilesZ; z++)
                    {
                        Vector3 pos = new Vector3((x * planeSize + playerX),
                                                    0,
                                                  (z * planeSize + playerZ));

                        string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();

                        if (!tiles.ContainsKey(tilename)) //We check if the plane is already active, if not we create a new plane
                        {
                            GameObject t = (GameObject)Instantiate(plane, pos,
                                           Quaternion.identity);
                            t.name = tilename;
                            Tile tile = new Tile(t, updateTime);
                            tiles.Add(tilename, tile);
                        }
                        else
                        {
                            (tiles[tilename] as Tile).creationTime = updateTime;
                        }
                    }
                }

                //We keep track of creation time and update time to destroy all tiles that are no longer accessible by player
                Hashtable newTerrain = new Hashtable();
                foreach (Tile tls in tiles.Values)
                {
                    if (tls.creationTime != updateTime)
                    {
                        //Deletes tile from list of tiles
                        Destroy(tls.theTile);
                    }
                    else
                    {
                        newTerrain.Add(tls.theTile.name, tls);
                    }
                }
                tiles = newTerrain;
                startPos = player.transform.position;
            }

        }
    }
}