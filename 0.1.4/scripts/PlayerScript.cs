using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : Unit
{
    private const float slowFactor = 0.35f;
    public float maxSpeed, speedFix, acceleration;

    private void Start() {
        speedFix = 1;
    }

    private void Update() {
        accelerationManager();
        handlerSlowShooting();
        movementHandler();
    }

    private void handlerSlowShooting () {
        if (Input.GetKeyDown(KeyCode.Space)) speedFix = slowFactor;
        else if (Input.GetKeyUp(KeyCode.Space)) speedFix = 1;
    }

    private void movementHandler () {
        if (Input.GetKey(KeyCode.W)) move(new Vector2(0, 1) * speedFix);
        else if (Input.GetKey(KeyCode.S)) move(new Vector2(0, -1) * speedFix);
        else move(Vector2.zero);
    }

    private void accelerationManager () {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)) speed = 0;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) {
            if (speed < maxSpeed) speed += acceleration * Time.deltaTime;
            else if (speed > maxSpeed) speed = maxSpeed;
        }
    }
}
