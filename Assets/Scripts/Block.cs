using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

public class Block : Tile {
    public GameObject Spawnthis;
    public Sprite[] SpriteList;

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
