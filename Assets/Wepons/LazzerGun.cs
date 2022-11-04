using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazzerGun : MonoBehaviour {

    public Transform hitpoint;
    public Transform Frompoint;
    public GameObject TheLazer;
    public SpriteRenderer sp;
    public Transform Head;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        RaycastHit2D Hit = Physics2D.Raycast(Frompoint.position, hitpoint.position-Frompoint.position, 15);
        Vector3 HitPo = Hit.point;
        if (Hit.point != Vector2.zero) {

            TheLazer.transform.position = (new Vector2(Frompoint.position.x, Frompoint.position.y) + Hit.point) / 2;
            Vector3 direction = HitPo - Frompoint.position;
            direction = Vector3.Normalize(direction);
            TheLazer.transform.right = direction;
            Vector3 scale = new Vector3(0.5f, 0.375f, 1);
            scale.x = Vector3.Distance(Frompoint.position, HitPo);
            // TheLazer.transform.localScale = scale*2;
            sp.size = scale;
            Head.transform.position = HitPo;
            Head.transform.right = direction;
        }
        else
        {
          
        }
        Debug.DrawRay( Frompoint.position, hitpoint.position - Frompoint.position);
    }
}
