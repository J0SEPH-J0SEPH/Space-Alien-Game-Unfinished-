using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CraftBlock : MonoBehaviour {

    public bool canCraft;
    public Image Au;

	// Update is called once per frame
	void Update () {
        if (canCraft){
            Au.color = Color.green;
        }
        else{
            Au.color = Color.yellow;
        }
	}
}
