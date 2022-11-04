using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

public class Block : Tile {
    public GameObject Spawnthis;
	// Use this for initialization
	/*void Start () {
        Debug.Log("yeahThis2");
    }
	
	// Update is called once per frame
	void Update () {
		
	}*/

   // public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    //{
    //    Instantiate(Spawnthis, position, transform.rotation);
    //}

#if UNITY_EDITOR
[MenuItem("Assets/Creat/Tile/Block")]
    public static void CreatBlock()
    {
        string path = EditorUtility.SaveFilePanelInProject("SaveBlock", "New Block", "asset", "SaveBlock", "Assets");
        if(path == "")
        {
            return;
        }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<Block>(), path);
    }
#endif

}
