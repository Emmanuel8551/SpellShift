using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDebuf : Debuf
{
    public float damage = 5f;
    private bool setted = false;

    private void setValues() {
        timeBTWinstances = 0.25f;
        numInstances = 4;
        setted = true;
    }

    public void startEffect () {
        if (!setted) setValues();
        if (curEffect != null) StopCoroutine(curEffect);
        curEffect = StartCoroutine(burning());
    }

    IEnumerator burning () {
        for(int i = 0; i < numInstances; i++){
            yield return new WaitForSeconds(timeBTWinstances);
            enemy.takeDamage(damage);
            if (i == numInstances - 1) endEffect();
        }   
    }
}
