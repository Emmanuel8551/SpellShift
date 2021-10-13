using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusCurse : MonoBehaviour
{
    public int numInstances = 1;
    public float frecuency = 1;
    internal Enemy enemy;
    internal bool setted;

    private void Awake() {
        setted = false;
        enemy = GetComponent<Enemy>();
    }

    public void startEffect () {
        if (!setted) setValues();
        if(canAddEffect()) addEffect();
    }

    public IEnumerator manageInstances () {
        for(int i = 0; i < numInstances; i++) {
            beforeEffect();
            yield return new WaitForSeconds(frecuency);
            afterEffect();
            if(checkIsOver()) endEffect();
        }
    }

    private void endEffect () {
       Destroy(this);
    }

    public virtual bool canAddEffect () {return true;}
    public virtual bool checkIsOver () {return true;}

    public virtual void beforeEffect() {}
    public virtual void afterEffect () {}

    public virtual void addEffect () {}
    public virtual void setValues () {}

}
