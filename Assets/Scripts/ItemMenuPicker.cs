using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenuPicker : MonoBehaviour {

    public static ItemMenuPicker instance;
    public SlotHolder[] Drags;
    public GameObject newItemSlot;
    public int Item;
    public Item[] ITMS;
    public int Amount;
	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void IdCheck()
    {
        Debug.Log("Works");
        foreach (SlotHolder ITMSlot in Drags)
        {
            if (ITMSlot.ItemID == Item)
            {
                ITMSlot.AddItem(Amount);
                return;
            }
        }
        CheckforEmpty();
    }

    void CheckforEmpty()
    {
        foreach(SlotHolder Slot in Drags)
        {
            if(Slot.transform.childCount == 0)
            {
                Slot.ItemID = Item;
                GameObject DR = Instantiate(newItemSlot, Slot.transform.position, Slot.transform.rotation, Slot.transform);
                DragHandler DRA = DR.GetComponent<DragHandler>();
                DRA.ITM = ITMS[Item];
                DRA.Itemamount = Amount; 
                return;
            }
        }
    }
    public void GiveItem(int ItemID) {
        Item = ItemID;
    }
    public void GiveItemAmount(int AmountGot)
    {
        Amount = AmountGot;
        IdCheck();
    }
}
