using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    // Bullet Types
    public GameObject normalBullet, fireBullet, lightningBullet, iceBullet;
    private GameObject curBullet;

    // Weapon specifics
    public int maxAmmo,  curAmmo;
    private float cadency, reloadTime, dispersion;
    private bool cadencyPassed, reloading;
    // Extras
    private Coroutine reloadCor;

    private void Start() {
        cadencyPassed = true;
        reloadTime = 1.35f;
        swapWeapon("normal");
    }
    
    private void Update() {
        // Attach handlers
        shootHandler();
        reloadHandler();
        
        // Swap weapons experimentation
        if (Input.GetKeyDown(KeyCode.E)) {
            if (curBullet == normalBullet) swapWeapon("ice");
            else if (curBullet == fireBullet) swapWeapon("normal");
        }

        // Frenzy Experimentation
        // if (Input.GetKeyDown(KeyCode.E)) {
        //     cadency /= 2;
        // }
    }

    ////////////////////// HANDLERS /////////////////////
    private void shootHandler () {
        if (Input.GetKey(KeyCode.Space) && curAmmo > 0 && cadencyPassed && !reloading) shoot();
    }
    
    private void reloadHandler () {
        float reloadTime = this.reloadTime;
        // Si ya se está recargando no se manda a llamar a recargar de nuevo
        if (reloading) return;

        // Si pasamos de una bala especial al normal el tiempo de recarga es cero
        if (curBullet != normalBullet) reloadTime = 0;

        if (Input.GetKeyDown(KeyCode.R)) reloadCor = StartCoroutine(reload(reloadTime));
        else if (Input.GetKey(KeyCode.Space) && curAmmo == 0) reloadCor = StartCoroutine(reload(reloadTime));
    }

    //////////////////// METHODS /////////////////////
    private void shoot () {
        GameObject bullet = Instantiate(curBullet) as GameObject;
        bullet.transform.position = transform.position;
        bullet.GetComponent<Bullet>().direction = new Vector2(1, Random.Range(-1, 1f)*dispersion/100).normalized;
        curAmmo--;
        // Invocamos el tiempo entre disparos
        StartCoroutine(waitCadency());
    }

    
    internal void swapWeapon (string type) {
        // BUG FIXED: If you catch a special on your lasts normal bullets the reload stops
        if (reloadCor != null && type != "normal") StopCoroutine(reloadCor);
        Debug.Log("Reload!");
        reloading = false;

        // Basic Weapon
        if (type == "normal") {
            curBullet = normalBullet;
            maxAmmo = curAmmo = 35;
            this.dispersion = 4;
            this.cadency = 0.125f;
        }
        // Fire Weapon
        if (type == "fire") {
            curBullet = fireBullet;
            maxAmmo = curAmmo = 45;
            this.dispersion = 12;
            this.cadency = 0.1f;
        }
        // Ice Weapon
        if (type == "ice")  {
            curBullet = iceBullet;
            maxAmmo = curAmmo = 55;
            this.dispersion = 6;
            this.cadency = 0.075f;
        }
        // Lightning Weapon
        if (type == "lightning")  {
            curBullet = lightningBullet;
            maxAmmo = curAmmo = 25;
            this.dispersion = 0;
            this.cadency = 0.15f;
        }
    }

    ///////////////////// TIMERS //////////////////////
    IEnumerator reload (float reloadTime) {
        Debug.Log("Reloading...");
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        swapWeapon("normal");
    }

    IEnumerator waitCadency () {
        cadencyPassed = false;
        yield return new WaitForSeconds(cadency);
        cadencyPassed = true;
    }
}
