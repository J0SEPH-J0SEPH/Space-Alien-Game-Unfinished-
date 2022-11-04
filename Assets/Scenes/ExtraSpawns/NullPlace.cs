using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class NullPlace : MonoBehaviour {
    public Tile block;
    public Tilemap highlightMap;
    // Use this for initialization
    void Start () {
        highlightMap = GenirateTerrain.instance.BuildMap;

        highlightMap.SetTile(new Vector3Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z)), null);
    }
}
