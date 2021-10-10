using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuf : MonoBehaviour
{
    public float timeBTWinstances;
    public int numInstances;
    internal Enemy enemy;
    internal Coroutine curEffect = null;

    private void Awake() {
        enemy = GetComponent<Enemy>();
    }

    public void endEffect () {
        Destroy(gameObject.GetComponent<FireDebuf>());
    }
}
