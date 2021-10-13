using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDebuf : Debuf
{
    public float damage = 5f;
    public int curBurningCoroutines;
    private bool setted = false;
    private Coroutine[] burnCoroutines = new Coroutine[3];


    private void setValues() {
        timeBTWinstances = 0.5f;
        numInstances = 4;
        setted = true;
    }

    // Adds burn effect is there is less than 3 stacks
    public void startEffect () {
        if (!setted) setValues();
        if (updateNumBurningCoroutines() < 3) addCoroutine(StartCoroutine(burning()));
    }

    // Pushes a coroutine to the stack of currently working coroutines
    private void addCoroutine (Coroutine burnCor) {
        for(int i = 0; i < burnCoroutines.Length; i++) {
            if (burnCoroutines[i] == null) {
                burnCoroutines[i] = burnCor;
                break;
            }
        }
        updateNumBurningCoroutines();
    }

    // Updates the number of current burning effects and return its value
    private int updateNumBurningCoroutines () {
        curBurningCoroutines = 0;
        for (int i = 0; i < burnCoroutines.Length; i++) {
            if (burnCoroutines[i] != null) curBurningCoroutines++;
        }
        return curBurningCoroutines;
    }

    // Removes the 1st/oldest burning effect
    private void removeBurnCoroutine () {
        for(int i = 0; i < burnCoroutines.Length; i++) {
            if (i < 2) burnCoroutines[i] = burnCoroutines[i+1];
            else burnCoroutines[i] = null;
        }
        updateNumBurningCoroutines();
    }

    // Inflicts damage to the enemy attached and when no burning effects active detachs
    IEnumerator burning () {
        for(int i = 0; i < numInstances; i++){
            yield return new WaitForSeconds(timeBTWinstances);
            enemy.takeDamage(damage);
            if (i == numInstances - 1) {
                removeBurnCoroutine();
                if (curBurningCoroutines == 0) endEffect();
            }
        }   
    }
}