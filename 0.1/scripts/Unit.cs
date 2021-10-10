using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float hp = 10;
    public float speed = 1;
    internal Rigidbody2D rb;

    private void Awake() {
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.gravityScale = 0;
    }

    internal void move (Vector2 direction) {
        rb.velocity = direction * speed;
    }

    internal virtual void takeDamage (float damage) {
        hp -= damage;
        if (hp <= 0) Destroy(gameObject);
    }
    
}
