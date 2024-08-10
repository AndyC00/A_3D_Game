using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (weapon != null && Input.GetKeyDown(KeyCode.J))
        {
            weapon.Attack();
        }


        void LoadWeapon(Weapon weapon)
        {
            this.weapon = weapon;
        }
        void UnloadWeapon()
        {
            weapon = null;
        }
    }
}
