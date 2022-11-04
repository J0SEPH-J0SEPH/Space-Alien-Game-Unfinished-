using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slotholder : MonoBehaviour {

    public int ItemID;

    // Update is called once per frame
    private void Start()
    {
        if (transform.childCount == 0)
        {
            ItemID = 0;
        }
    }

    public void Checkslot (int ID) {
		if(transform.childCount != 0)
        {
            ItemID = ID;
        }
        else
        {
            ItemID = 0;
        }
	}
    public void AddItem(int amount)
    {
        Debug.Log("yessThisTo");
        DragHandler DR = transform.GetComponentInChildren<DragHandler>();
        DR.Itemamount += amount;
        DR.Getsome();
    }
}
