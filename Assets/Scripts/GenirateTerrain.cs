using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GenirateTerrain : MonoBehaviour {

    public static GenirateTerrain instance;
    public Block[] Blocks;
    public Block[] BackgroundBlocks;
    public Tilemap BuildMap;
    public Tilemap background;
    private Vector3Int blockplacepoinnt;

    public int seed;
    public float hightmultplyer;
    public float hightAdd;
    public float smoothness;
    public int BaseSpawn;
    public int TreeSpawn;
    public GameObject[] basses;
    public GameObject tree;

    private Dictionary<Vector2,int> TilesInfo = new Dictionary<Vector2, int>();

    private Dictionary<int, int> BlockTypes = new Dictionary<int, int>();

    void Start () {
        instance = this;

        BlockTypes.Add(0, 0);
        BlockTypes.Add(1, 2);
        BlockTypes.Add(10, 3);
        BlockTypes.Add(100, 4);
        BlockTypes.Add(1000, 1);
        BlockTypes.Add(11, 29);
        BlockTypes.Add(110, 7);
        BlockTypes.Add(1100, 28);
        BlockTypes.Add(1001, 5);
        BlockTypes.Add(101, 8);
        BlockTypes.Add(1010, 6);
        BlockTypes.Add(1111, 13);
        BlockTypes.Add(1011, 10);
        BlockTypes.Add(1110, 11);
        BlockTypes.Add(1101, 9);
        BlockTypes.Add(111, 12);

        BlockTypes.Add(10000, 14);
        BlockTypes.Add(100000, 15);
        BlockTypes.Add(1000000, 16);
        BlockTypes.Add(10000000, 17);
        BlockTypes.Add(110000, 18);
        BlockTypes.Add(1100000, 19);
        BlockTypes.Add(1010000, 20);
        BlockTypes.Add(10010000, 21);
        BlockTypes.Add(10100000, 22);
        BlockTypes.Add(11000000, 23);
        BlockTypes.Add(1110000, 24);
        BlockTypes.Add(11100000, 25);
        BlockTypes.Add(11010000, 26);
        BlockTypes.Add(10110000, 27);

        seed = Random.Range(0,10);
        BaseSpawn = Random.Range(3, 27);
        TreeSpawn = Random.Range(1, 5);
        Create();
    }

    void Create()
    {
      
        for(int i = 0; i < 60; i++){
            //int h = Mathf.RoundToInt(Mathf.PerlinNoise(seed, (i*0.3f) * smoothness) * hightmultplyer + hightAdd);

            for (int j = 0; j < 40; j++)
            {
                /* if (i == BaseSpawn && j == h-10)
                 {
                     Instantiate(basses[Random.Range(0,basses.Length)], new Vector3(i, -j, 0), transform.rotation);
                 }
                 if (i== TreeSpawn && j== h-10)
                 {
                     Instantiate(tree, new Vector3(i, -j, 0), transform.rotation);

                     TreeSpawn = Random.Range(TreeSpawn+1,TreeSpawn+8);

                 }*/
               
                if (CaclulateNoise(i,j) > 0.1f){
                    // if (BlockTypes.ContainsValue(CheckifEdgeBlock(i, j, 0)))
                    // {
                    Block BLK = Blocks[0];
                    BLK.sprite = BLK.SpriteList[BlockTypes[CheckifEdgeBlock(i, j, 0)]];
                    Block BGBLK = BackgroundBlocks[0];
                    BGBLK.sprite = BGBLK.SpriteList[BlockTypes[CheckifEdgeBlock(i, j, 0)]];

                    SetBlock(i, j, BLK, BGBLK);
                   // }
                    TilesInfo.Add(new Vector2(transform.position.x+i, transform.position.y - j), 1);
                }
                else
                {
                    TilesInfo.Add(new Vector2(transform.position.x + i, transform.position.y - j), 0);

                }
            }
        }
    }

    float CaclulateNoise(int XPos, int YPos)
    {
        float noise = PerlinCalcualtion(XPos, YPos, 0.3f) + PerlinCalcualtion(XPos, YPos, 0.2f) + PerlinCalcualtion(XPos, YPos, 0.1f);
        noise = noise * 0.3f;
        noise += -(Vector2.Distance(new Vector2(0, YPos), new Vector2(0, 20)) * 0.03f) - (Vector2.Distance(new Vector2(XPos, 0), new Vector2(30, 0)) * 0.01f);

        return noise;
    }

    float PerlinCalcualtion(int XPos,int YPos,float Size)
    {
        return Mathf.PerlinNoise((XPos + seed * 1000) * Size, (YPos + seed * 1000) * Size);
    }

    void SetBlock(int XPos, int YPos, Block Block, Block BackgroundBlock)
    {
        blockplacepoinnt = new Vector3Int(XPos, -YPos, 0);
        BuildMap.SetTile(blockplacepoinnt, Block);
        background.SetTile(blockplacepoinnt, BackgroundBlock);
       
    }

    int CheckifEdgeBlock(int XPos, int YPos,int Default) {

        int numb = 0;
        
        if (CaclulateNoise(XPos - 1, YPos)<0.1f){
            numb += 1;
        }
        if (CaclulateNoise(XPos + 1, YPos) < 0.1f){
            numb += 10;
        }
        if(CaclulateNoise(XPos, YPos + 1) < 0.1f){
            numb += 100;
        }
        if (CaclulateNoise(XPos, YPos - 1) < 0.1f){
            numb += 1000;
        }
        if (numb == 0)
        {
            if (CaclulateNoise(XPos - 1, YPos - 1) < 0.1f){
                numb += 10000;
            }
            if (CaclulateNoise(XPos + 1, YPos - 1) < 0.1f){
                numb += 100000;
            }
            if (CaclulateNoise(XPos - 1, YPos + 1) < 0.1f){
                numb += 1000000;
            }
            if (CaclulateNoise(XPos + 1, YPos + 1) < 0.1f){
                numb += 10000000;
            }
        }
        if (!BlockTypes.ContainsKey(numb)){
            print(numb);
        }
       

        return numb;
    }

    int CheckBlocksAroundTile(int XPos, int YPos){

        int numb = 0;
        

        if (BuildMap.GetTile(new Vector3Int(XPos - 1, YPos, 0)) == null){
            numb += 1;
        }

        if (BuildMap.GetTile(new Vector3Int(XPos + 1, YPos, 0)) == null){
            numb += 10;
        }
        if (BuildMap.GetTile(new Vector3Int(XPos , YPos - 1, 0)) == null){
            numb += 100;
        }
        if (BuildMap.GetTile(new Vector3Int(XPos, YPos + 1, 0)) == null) {
            numb += 1000;
        }
        if (numb == 0)
        {
            if (BuildMap.GetTile(new Vector3Int(XPos - 1, YPos +1, 0)) == null){
                numb += 10000;
            }
            if (BuildMap.GetTile(new Vector3Int(XPos + 1, YPos + 1, 0)) == null){
                numb += 100000;
            }
            if (BuildMap.GetTile(new Vector3Int(XPos - 1, YPos - 1, 0)) == null){
                numb += 1000000;
            }
            if (BuildMap.GetTile(new Vector3Int(XPos + 1, YPos - 1, 0)) == null){
                    numb += 10000000;
            }
        }
            return numb;
    }

    public void RemoveChunk(Vector2Int size, Vector2Int HitPoint)
    {
        int XSize = Mathf.RoundToInt((size.x * 0.5f) - 0.5f);
        int Yize = Mathf.RoundToInt((size.y * 0.5f) -0.5f);

        float XSizePos = size.x * 0.7f;

        for (int i = -XSize; i < XSize; i++)
        {
            for (int j = -Yize; j < Yize; j++)
            {
                float DistanceFromHit = Vector2.Distance(new Vector2(i + HitPoint.x, j + HitPoint.y), HitPoint);

                if (DistanceFromHit < XSizePos - 2)
                {
                    BuildMap.SetTile(new Vector3Int(i + HitPoint.x, j + HitPoint.y, 0), null);

                   TilesInfo[new Vector2(i + HitPoint.x, j + HitPoint.y)] = 0;
                 
                }
            }
        }
        for (int i = -XSize; i < XSize + 1; i++)
        {
            for (int j = -Yize; j < Yize+1; j++)
            {
                if (BuildMap.GetTile(new Vector3Int(i + HitPoint.x, j + HitPoint.y, 0)) != null)
                {
                    float DistanceFromHit = Vector2.Distance(new Vector2(i + HitPoint.x, j + HitPoint.y), HitPoint);

                    if (DistanceFromHit > XSize - 1 && DistanceFromHit < XSize+1)
                    {
                        Block BLK = Blocks[0];
                        
                        int TileType = CheckBlocksAroundTile(i + HitPoint.x, j + HitPoint.y);
                        print(TileType);

                        BLK.sprite = BLK.SpriteList[BlockTypes[TileType]];
                        blockplacepoinnt = new Vector3Int(i + HitPoint.x, j + HitPoint.y, 0);
                        BuildMap.SetTile(blockplacepoinnt, null);
                        BuildMap.SetTile(blockplacepoinnt, BLK);

                    }
                }
            }
        }
    }
}
