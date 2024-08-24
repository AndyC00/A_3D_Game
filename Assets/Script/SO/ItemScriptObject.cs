using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSO : ScriptableObject
{
    public string Name { get; set; }
    public ItemType ItemType { get; set; }

}

public enum ItemType
{ 
    Weapon,
    Consumable
}