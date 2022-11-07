using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour {
    public static ItemList instance;
    public int[] theAmount;
    public Craftingslot[] craftable;
    // Use this for initialization
    void Start () {
        instance = this;
	}
    private void Update()
    {
        if (Input.GetKeyDown("i")){
            RegisterItem();
        }
    }


    // Update is called once per frame
    public void RegisterItem () {
      foreach(Craftingslot Slot in craftable)
        {
            Slot.Hasitem();
        }
	}
}
