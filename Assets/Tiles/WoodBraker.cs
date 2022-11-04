using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class WoodBraker : MonoBehaviour {

    public GameObject Itemsin;
    public int HP;
    public Tilemap background;
    public bool Dead = false;
    // Use this for initialization
    void Start () {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Dead && collision.CompareTag("Breacker")) {
            HP -= 1;
            background = GenirateTerrain.instance.background;
            Invoke("DeadBlock", 0.1f);
        }

    }

    void DeadBlock()
    {
        Spawn();
        Dead = true;
        background.SetTile(new Vector3Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z)), null);
    }
    void Spawn()
    {
        Instantiate(Itemsin, new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, 0), transform.rotation);
    }
}
