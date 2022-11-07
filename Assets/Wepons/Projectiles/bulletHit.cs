using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour {

    public GameObject Excriment;
    public Rigidbody2D RB;
    public float speed = 100;
    public GenirateTerrain TerrainGen;
    public int ExploshionSize = 3;
	// Use this for initialization
	void Start () {
        RB.AddForce(transform.right*-speed,ForceMode2D.Impulse);
	}


    /* void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.CompareTag("Ground"))
         {
             Instantiate(Excriment, transform.position, transform.rotation);
             Destroy(gameObject);
         }
     }*/

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            TerrainGen.RemoveChunk(new Vector2Int(ExploshionSize, ExploshionSize), new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y)));
            Destroy(gameObject);
        }
    }
}
