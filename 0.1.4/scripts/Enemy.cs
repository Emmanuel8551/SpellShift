using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    internal int danger;
    public GameObject deathExplosion;
    internal BoxCollider2D col;
    internal SpriteRenderer sp;
    public Sprite normal, damaged;
    private Coroutine curDamageEffect;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();

        gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
        move(new Vector2(-1, 0));
    }

    internal override void takeDamage (float damage) {
        hp -= damage;
        if (hp <= 0) die ();
        else handleDamageEffect();
    }

    private void die () {
        Instantiate(deathExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    } 

    // Visuals
    private void handleDamageEffect () {
        if (curDamageEffect == null) curDamageEffect = StartCoroutine(damagaEffect());
        else {
            StopCoroutine(curDamageEffect);
            curDamageEffect = StartCoroutine(damagaEffect());
        }
        
    }
    IEnumerator damagaEffect () {
        sp.sprite = damaged;
        yield return new WaitForSeconds(0.06f);
        sp.sprite = normal;
    }
}
