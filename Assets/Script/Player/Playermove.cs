using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    private Animator animator;
    private float stopThreshold = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            bool isCollide = Physics.Raycast(ray, out hit);
            if (isCollide)
            {
                if (hit.collider.tag == "Ground")
                {
                    playerAgent.isStopped = false;
                    playerAgent.stoppingDistance = 0.2f;
                    playerAgent.updateRotation = true;
                    playerAgent.SetDestination(hit.point);
                }
                else if (hit.collider.tag == "Interactable")
                {
                    hit.collider.GetComponent<InteractableObject>().OnClick(playerAgent);
                }
                
            }
        }

        //animation controller:
        if (!playerAgent.pathPending && playerAgent.remainingDistance <= playerAgent.stoppingDistance + stopThreshold)
        {
            animator.SetBool("isWalking", false);
            playerAgent.isStopped = true;
            playerAgent.updateRotation = false;
        }
        else if (playerAgent.velocity.sqrMagnitude > 0.01f)
        {
            animator.SetBool("isWalking", true);
        }
    }
}
