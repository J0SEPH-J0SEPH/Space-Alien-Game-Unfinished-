using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {
    public int ID;
    public int amount;

    // Use this for initialization
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ItemList.instance.theAmount[ID] += amount;
            ItemMenuPicker.instance.Item = ID;
            ItemMenuPicker.instance.Amount = amount;
            ItemMenuPicker.instance.IdCheck();
            Destroy(gameObject);
        }
    }
}
