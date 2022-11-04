using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sausa : MonoBehaviour {


    public Rigidbody2D RB;
    public Vector3 Velocity;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float V = Input.GetAxis("Vertical");
        float H = Input.GetAxis("Horizontal");

       

        RB.AddForce(Vector3.up * V * 200, ForceMode2D.Force);
     
        
        RB.AddForce(Vector3.right * H * 400, ForceMode2D.Force);
 
        if(RB.velocity.y < -10)
        {
            RB.velocity= new Vector3(RB.velocity.x,-10,0);
        }
        if (RB.velocity.y > 10)
        {
            RB.velocity = new Vector3(RB.velocity.x, 10, 0);
        }
        if (RB.velocity.x < -10)
        {
            RB.velocity = new Vector3(-10, RB.velocity.y, 0);
        }
        if (RB.velocity.x > 10)
        {
            RB.velocity = new Vector3(10, RB.velocity.y, 0);
        }

    }
}
