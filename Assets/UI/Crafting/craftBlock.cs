using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class craftBlock : MonoBehaviour {

    public bool canCraft;
    public Image Au;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (canCraft)
        {
            Au.color = Color.green;
        }
        else
        {
            Au.color = Color.yellow;
        }
	}
}
