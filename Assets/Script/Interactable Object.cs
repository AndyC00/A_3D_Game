using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteractableObject : MonoBehaviour
{
    public void OnClick(NavMeshAgent playerAgent)
    {
        playerAgent.SetDestination(transform.position);

        Interact();
    }

    protected virtual void Interact()
    {
        print("Interacting with Interactable Object.");
    }
}