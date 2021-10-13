using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : Unit
{
    public string type;

    internal override void takeDamage (float damage) {
        hp -= damage;
        if(hp <= 0) {
            GameObject.Find("Player").GetComponent<WeaponScript>().swapWeapon(type);
            Destroy(transform.parent.gameObject);
        }
    }
}
