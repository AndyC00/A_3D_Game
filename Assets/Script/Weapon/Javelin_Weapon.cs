using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinWeapon : Weapon
{
    public float bulletSpeed;
    public GameObject bulletPrefab;
    public override void Attack()
    {
        GameObject bulletGo = GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation);
        bulletGo.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    }
}
