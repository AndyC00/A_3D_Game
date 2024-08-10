using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItems : InteractableObject
{
    protected override void Interact()
    {
        print("Interacting with items");
    }
}