using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Items/Default")]
public class Item : ScriptableObject {
    public int ID;
    public Sprite Image;
    public int MaxAmount;
}
