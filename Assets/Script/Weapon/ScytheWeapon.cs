using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheWeapon : Weapon
{
    public const string ANIM_PARM_ISATTACK = "IsAttack";

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //Press "J" to attack
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
    }

    public override void Attack()
    {
        anim.SetTrigger(ANIM_PARM_ISATTACK); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //todo: enemy
            print("Trigger with " + other.name);
        }
    }
}
