using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craftingslot : MonoBehaviour {

    public int[] itemIdNeeded;
    public int[] amount;
    public int maxcrafnumber = 1;
    public ItemList LO;
    public GameObject CraftTyle;
    public craftBlock Craft;
    // Update is called once per frame

    public void Hasitem () {
        int craftnumber = 0;
        bool CanCraft;
        int current = 0;
        foreach (int ID in itemIdNeeded)
        {
            if (LO.theAmount[ID] >= amount[current])
            {
                craftnumber += 1;
            }else if (LO.theAmount[ID] <= 0)
            {
                CanCraft = false;
                Isnull();
                return;
            }
            else
            {
                craftnumber = 0;
            }
            current += 1;
        }
        if(craftnumber >= maxcrafnumber)
        {
            Craft.canCraft = true;
            CraftTyle.SetActive(true);
        }
        else
        {
            Craft.canCraft = false;
            CraftTyle.SetActive(true);
        }
	}
    public void Isnull()
    {
        CraftTyle.SetActive(false);
    }
}
