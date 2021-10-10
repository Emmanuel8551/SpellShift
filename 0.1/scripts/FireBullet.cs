using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet
{
    public int drillThreshold;
    public override void hit (GameObject obj) {
        if (obj.GetComponent<Enemy>() != null) {
            Enemy es = obj.GetComponent<Enemy>();
            if (es.hp > drillThreshold) die();
            es.takeDamage(damage);
            if (obj.GetComponent<FireDebuf>() == null) obj.AddComponent<FireDebuf>().startEffect();
            else obj.GetComponent<FireDebuf>().startEffect();
        }
        if (obj.GetComponent<Element>() != null) {
            Element el = obj.GetComponent<Element>();
            el.takeDamage(damage);
        }
    }
    
    public override void die () {
        Destroy(gameObject);
    }
    
}
