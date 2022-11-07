using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepRotation : MonoBehaviour {
    // Update is called once per frame
    public void keepEyeRot () {
        transform.rotation = Quaternion.Euler(Vector3.zero);
	}
}
