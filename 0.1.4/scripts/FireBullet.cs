using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet
{
    public int drillThreshold;
    public override void hit (GameObject obj) {
        // If the colided obj is an enemy
        if (obj.GetComponent<Enemy>() != null) {
            Enemy es = obj.GetComponent<Enemy>();
            es.takeDamage(damage);

            // Chance drill
            if (!calcProc(0.8f)) die();
            // Add burning effect
            if (obj.GetComponent<FireDebuf>() == null) obj.AddComponent<FireDebuf>().startEffect();
            else obj.GetComponent<FireDebuf>().startEffect();
        }
        // If is an element
        if (obj.GetComponent<Element>() != null) obj.GetComponent<Element>().takeDamage(damage);
    }
    
    public override void die () {
        Destroy(gameObject);
    }
    
}
