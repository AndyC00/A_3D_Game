using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheWeapon : Weapon
{
    public const string ANIM_PARM_ISATTACK = "IsAttack";

    // This should be set in the Inspector or in another script
    public float damageInterval = 1.0f; // Time in seconds between damage applications

    private Animator anim;
    private float lastDamageTime = 0f; // Keeps track of when damage was last applied

    private void Start()
    {
        anim = GetComponentInParent<Animator>(); // Assuming the weapon is a child of the character
    }

    public override void Attack()
    {
        anim.SetTrigger(ANIM_PARM_ISATTACK);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(Tag.ENEMY))
        {
            if (Time.time >= lastDamageTime + damageInterval)
            {
                // Reduce enemy HP
                other.GetComponent<Enemy>().TakeDamage(AttackValue);
                lastDamageTime = Time.time; // Update the last time damage was applied
            }
        }
    }
}
