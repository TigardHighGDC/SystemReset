using UnityEngine;
using System.Collections.Generic;

// basicShoot.cs
// Generic shoot script for hitscan type weapons
public class basicShoot : MonoBehaviour
{
    // HashSet used to identify what rayCast is allowed to collide with
    // Targets for rayCast must have tage of type x for rayCast.hit to be called
    // on said object, HashSet is const and is initalized on start
    HashSet<string> enemies  =  new HashSet<string>();
    void Start()
    {
        enemies.Add("enemy");
        enemies.Add("ankleBiter");
    }

    // Gun stats
    public int damage;
    public float timeBetweenShots, spread, reloadTime, fireRate, range;
    public int magSize, shotsPerTap;
    public bool allowButtonHold;

    private int bulletsLeft;
    private bool shooting = false, readyToShoot = true, reloading = false;

    // Reference
    public Camera fpsCam;

    // Public Transform attackPoint
    public RaycastHit rayHit;

    private void Awake() {
        bulletsLeft = magSize;
        readyToShoot = true;
    }

    // Once per frame update
    private void Update() 
    {
        if (allowButtonHold) 
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        } 
        else 
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        // 'R' is the reload button
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magSize && !reloading) 
        {
            Reload();
            Debug.Log("Reloading...");
        }

        // Shoot call
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0) 
        {
            Shoot();
            Debug.Log("This is a shot");
            Debug.Log(bulletsLeft);
        }
    }

    private void Shoot() 
    {
        readyToShoot = false;
        bulletsLeft--;

        // Spread mechanism
        float spreadX = Random.Range(-spread, spread);
        float spreadY = Random.Range(-spread, spread);
        Vector3 bulletDirection = fpsCam.transform.forward + new Vector3(
            spreadX, spreadY, 0);

        // RayCast hitdetection
        // Target must have tage of type x contained in the hash table define
        // on line TODO and also have the Health component
        if (Physics.Raycast(fpsCam.transform.position, bulletDirection, 
            out rayHit, range)) 
        {
            if(enemies.Contains(rayHit.collider.tag))
            {
                rayHit.collider.GetComponent<Health>().TakeDamage(damage);
            }
        }

        // Wait fire rate
        Invoke("ResetShot", fireRate);
    }

    private void ResetShot() 
    {
        readyToShoot = true;
    }

    private void Reload() 
    {
        reloading = true;
        Invoke("FinishReload", reloadTime);
    }

    private void FinishReload() 
    {
        bulletsLeft = magSize;
        reloading = false;
        Debug.Log("Done reloading...");
    }
}