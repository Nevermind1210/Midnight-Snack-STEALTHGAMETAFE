using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public class InfiniteGeneration : MonoBehaviour
{
    public GameObject plane;
    public GameObject player;

    private int planeSize = 10;
    private int halfTilesZ = 10;
    private int halfTilesX = 10;

    private Vector3 startPos;

    private Hashtable tiles = new Hashtable();
    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = Vector3.zero;
        startPos = Vector3.zero;

        float updateTime = Time.realtimeSinceStartup;

        for (int x = -halfTilesX; x < halfTilesX; x++)
        {
            for (int z = -halfTilesZ; z < halfTilesZ; z++)
            {
                Vector3 pos = new Vector3((x * planeSize + startPos.x),
                    0,
                    (z * planeSize + startPos.z));
                GameObject t = (GameObject) Instantiate(plane, pos,
                    Quaternion.identity);

                string tilename = "Tile_" + ((int) (pos.x)).ToString() + "_" + ((int) (pos.z)).ToString();
                t.name = tilename;
                Tile tile = new Tile(t, updateTime);
                tiles.Add(tilename,tile);
            }
        }
    }
}
