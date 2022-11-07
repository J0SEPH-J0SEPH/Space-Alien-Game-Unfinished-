using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGun : MonoBehaviour {

    public GameObject bullet;
    public Transform Pointer;
    public GenirateTerrain GenTerrain;
    // Use this for initialization


    // Update is called once per frame
    public void ShootGun () {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject Bullet =  Instantiate(bullet, Pointer.position, Pointer.rotation);
            Bullet.GetComponent<bulletHit>().TerrainGen = GenTerrain;
        }
	}
}
