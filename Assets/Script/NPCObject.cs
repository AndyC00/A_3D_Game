using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCObject : InteractableObject
{
    public string name;
    public string[] contentList;

    public DialogueUI dialogueUI;
    protected override void Interact()
    {
        dialogueUI.Show(name, contentList);
    }
}
