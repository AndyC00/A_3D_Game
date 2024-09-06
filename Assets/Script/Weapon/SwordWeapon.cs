using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : Weapon
{
    public const string ANIM_PARM_ISATTACK = "IsAttack";

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public override void Attack()
    {
        anim.SetTrigger(ANIM_PARM_ISATTACK); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tag.ENEMY)
        {
            other.GetComponent<Enemy>().TakeDamage(AttackValue);
        }
    }
}