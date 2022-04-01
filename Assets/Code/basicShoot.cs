using UnityEngine;
using System.Collections.Generic;

// basicShoot.cs
// Generic shoot script for hitscan type weapons
public class basicShoot : MonoBehaviour
{
    // HashSet used to identify what rayCast is allowed to collide with
    // Targets for rayCast must have tag of type x for rayCast.hit to be called
    // on said object, HashSet is const and is initalized on start
    HashSet<string> enemies = new HashSet<string>();

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

    private int bulletsLeft, bulletsShot;
    private bool shooting = false, readyToShoot = true, reloading = false;

    /* Recoil */
    // Rotations
    private Vector3 currentRotation;
    private Vector3 targetRotation;

    // Properties
    public float recoilX;
    public float recoilY;
    public float recoilZ;

    // Tweaks
    public float snappiness;
    public float returnSpeed;

    // Reference
    public Camera fpsCam;

    // Public Transform attackPoint
    public RaycastHit rayHit;

    private void Awake() 
    {
        bulletsLeft = magSize;
        readyToShoot = true;
    }

    // Once per frame update
    private void Update() 
    {
        // Update Recoil
        targetRotation = Vector3.Lerp(
            targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(
            currentRotation, targetRotation, snappiness * Time.deltaTime);
        
        // Update player camera
        transform.localRotation = Quaternion.Euler(currentRotation);

        // Detect Shot
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
            Debug.Log("Reloading..."); // TODO: Remove debug
        }

        // Shoot call
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0) 
        {
            bulletsShot = shotsPerTap;
            Shoot();

            Debug.Log(bulletsLeft); // TODO: Remove debug
        }
    }

    private void Shoot() 
    {
        readyToShoot = false;
        bulletsLeft--;

        // Spread mechanism
        float spreadX = Random.Range(-spread, spread);
        float spreadY = Random.Range(-spread, spread);
        Vector3 bulletDirection = fpsCam.transform.forward + 
            new Vector3(spreadX, spreadY, 0);

        // RayCast hitdetection
        // Target must have tage of type x contained in the hash table define
        // on line 11 and also have the Health component
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
        bulletsLeft--;
        bulletsShot--;

        // Recurse if it is a burst gun
        if (bulletsShot > 0 && bulletsLeft > 0) 
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }

    private void RecoilFire()
    {
        float newX = Random.Range(-recoilX, recoilX);
        float newY = Random.Range(0, recoilY);
        float newZ = Random.Range(-recoilZ, recoilZ);

        targetRotation += new Vector3(newX, newY, newZ);
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
        Debug.Log("Done reloading..."); // TODO: Remove debug
    }
}