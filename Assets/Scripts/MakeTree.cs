using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class MakeTree : MonoBehaviour {
    public Tile Tree;
    public Tile Leaves;
    public Tilemap Background;
    public GameObject TreeBreack;
    private Transform TreeRoot;
    // Use this for initialization
    void Start()
    {
        TreeRoot = Instantiate(TreeBreack, transform.position, transform.rotation).transform;
        Background = GenirateTerrain.instance.background;
        TreeRoot.SetParent(Background.transform);
        int Size = Random.Range(4, 10);

        for (int i = 0; i < Size; i++)
        {
            Vector3Int blockplacepoinnt = new Vector3Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y)+ i+1, 0);
            Transform TreeBrantch = Instantiate(TreeBreack, transform.position + Vector3.up*i, transform.rotation).transform;
            TreeBrantch.SetParent(TreeRoot);
            TreeRoot = TreeBrantch;
            Background.SetTile(blockplacepoinnt, Tree);
            if(i == Size-1)
            {
                Background.SetTile(blockplacepoinnt, Leaves);
            }
        }
    }
}
