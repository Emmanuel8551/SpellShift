using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCurse : StatusCurse
{
    public float slow = 0.10f;
    private Coroutine curEffect;
    public float[] slows = new float[5];
    private float initialSpeed;

    public override void setValues () {
        this.initialSpeed = enemy.speed;
        this.curEffect = null;
        this.frecuency = 6;
        setted = true;
    }

    public override void addEffect () {
        if (curEffect != null) StopCoroutine(curEffect);
        curEffect = StartCoroutine(manageInstances());
    }

    public override void beforeEffect () {
        pushSlow();
        applySlows();
    }

    public void applySlows () {
        enemy.speed = initialSpeed;
        foreach(float slow in slows) {
            enemy.speed -= slow * initialSpeed;
        }
        enemy.move(new Vector2(-1, 0));
    }

    public override void afterEffect () {
        enemy.speed = initialSpeed;
        enemy.move(new Vector2(-1, 0));
    }

    private void pushSlow () {
        for (int i = 0; i < slows.Length; i++) {
            if (slows[i] == 0) {
                slows[i] = slow;
                return;
            }
        }
    }

    public override bool canAddEffect () {
        return true;
    }

    public override bool checkIsOver () {
        for (int i = 0; i < slows.Length; i++) {
            if (slows[i] == 0) return false;
        }
        return true;
    }
}
