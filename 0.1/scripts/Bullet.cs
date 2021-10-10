using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Unit
{
    internal Vector2 direction;
    public Transform trail;
    public GameObject explosion;
    public int damage;

    private void Start() {
        move(direction);
        gameObject.AddComponent<PolygonCollider2D>().isTrigger = true;
    }

    private void Update() {
        if(transform.position.magnitude > 10) Destroy(gameObject);
    }

    ////////////////// HANDLERS ////////////////////
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("unit")) {
            hit(other.gameObject);
        }
    }   

    /////////////////// METHODS ////////////////////
    public virtual void hit (GameObject obj) {
        if (obj.GetComponent<Enemy>() != null) obj.GetComponent<Enemy>().takeDamage(damage);
        if (obj.GetComponent<Element>() != null) obj.GetComponent<Element>().takeDamage(damage);
        die();
    }

    public virtual void die () {
        trail.parent = null;
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
}
