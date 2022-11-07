using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlockBreacker : MonoBehaviour {


    public Tile highlightTile;
    public Tilemap highlightMap;
    public Tilemap BuildMap;
    private Vector3Int previous;
    private Vector3Int currentCell;
    public Vector3 mousepose;
	
	// Update is called once per frame
	void LateUpdate () {
        mousepose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0)){
            BuildMap.SetTile(currentCell, null);
        }

        currentCell = highlightMap.WorldToCell(mousepose);

        if (currentCell != previous){
            // set the new tile
            highlightMap.SetTile(currentCell, highlightTile);
            // erase previous
            highlightMap.SetTile(previous, null);
            // save the new position for next frame
            previous = currentCell;
        }
    }
}
