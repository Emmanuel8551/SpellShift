using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    public float speed;
    private Rigidbody2D rb;
    
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        movementHandler();
    }

    private void movementHandler () {
        if (Input.GetKey(KeyCode.W)) move(new Vector2(0, 1));
        else if (Input.GetKey(KeyCode.S)) move(new Vector2(0, -1));
        else move(Vector2.zero);
    }

    private void move (Vector2 direction) {
        rb.velocity = direction * speed;
    }
}
