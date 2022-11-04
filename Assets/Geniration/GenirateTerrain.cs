using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GenirateTerrain : MonoBehaviour {

    public static GenirateTerrain instance;
    public Tile[] Blocks;
    public Tile BackgroundBlocks;
    public Tilemap BuildMap;
    public Tilemap background;
    private Vector3Int blockplacepoinnt;

    public int seed;
    public float hightmultplyer;
    public float hightAdd;
    public float smoothness;
    private int sizebuff;
    public int BaseSpawn;
    public int TreeSpawn;
    public GameObject[] basses;
    public GameObject tree;
    void Start () {
        instance = this;
        seed = Random.Range(0, 100000000);
        BaseSpawn = Random.Range(3, 27);
        TreeSpawn = Random.Range(1, 5);
        Create();
    }
	
	// Update is called once per frame
	void Update () {

	}

    void Create()
    {
      
        for(int i = 0; i < 30; i++)
        {
            if (i <= 10)
            {
                sizebuff = i;
            }
            if (i >= 20)
            {
                sizebuff = 31 - i;
            }

            int h = Mathf.RoundToInt(Mathf.PerlinNoise(seed, (i*0.3f) * smoothness) * hightmultplyer + hightAdd);

            


            for (int j = h-10; j < (h-1)+ sizebuff; j++)
            {
                if (i == BaseSpawn && j == h-10)
                {
                    Instantiate(basses[Random.Range(0,basses.Length)], new Vector3(i, -j, 0), transform.rotation);
                }
                if (i== TreeSpawn && j== h-10)
                {
                    Instantiate(tree, new Vector3(i, -j, 0), transform.rotation);

                    TreeSpawn = Random.Range(TreeSpawn+1,TreeSpawn+8);
                    
                }
                blockplacepoinnt =new  Vector3Int(i, -j, 0);
                BuildMap.SetTile(blockplacepoinnt, Blocks[0]);
                background.SetTile(blockplacepoinnt, BackgroundBlocks);

            }


        }

    }
}
