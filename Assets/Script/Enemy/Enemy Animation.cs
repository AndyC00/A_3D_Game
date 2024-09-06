using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    public bool isWalking;
    private Transform playerTransform;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {
        animator.SetBool("isWalking", isWalking);

        if (Vector3.Distance(transform.position, playerTransform.position) > 5f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }
}
