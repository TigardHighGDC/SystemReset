/*
*   Copyright 2022 TigardHighGDC
*
*   Licensed under the Apache License, Version 2.0 (the "License");
*   you may not use this file except in compliance with the License.
*   You may obtain a copy of the License at
*
*   http://www.apache.org/licenses/LICENSE-2.0
*
*   Unless required by applicable law or agreed to in writing, software
*   distributed under the License is distributed on an "AS IS" BASIS,
*   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
*   See the License for the specific language governing permissions and
*   limitations under the License.
*/

using UnityEngine;
using System.Collections.Generic;

// Generic shoot script for hitscan type weapons
public class basicShoot : MonoBehaviour
{
    // HashSet used to identify what rayCast is allowed to collide with
    // Targets for rayCast must have tag of type x for rayCast.hit to be called
    // on said object, HashSet is const and is initalized on start
    HashSet<string> enemies = new HashSet<string>();

    // Gun stats
    public float damage;
    public float timeBetweenShots, spread, reloadTime, fireRate, range;
    public int magSize, shotsPerTap;
    public bool allowButtonHold;

    private int bulletsLeft, bulletsShot;
    private bool shooting = false, readyToShoot = true, reloading = false;

    /* Recoil */
    private cameraRecoil Recoil_Script;

    /* Player references */
    // Reference
    public Camera fpsCam;

    // Public Transform attackPoint
    public RaycastHit rayHit;

    // Add targetable tags to hashset
    private void Start()
    {
        enemies.Add("enemy");
        enemies.Add("ankleBiter");

        // Grab the Recoil Class From CameraRecoil
        Recoil_Script = GetComponentInParent<cameraRecoil>();
    }

    private void Awake() 
    {
        bulletsLeft = magSize;
        readyToShoot = true;
    }

    // Once per frame update
    private void Update() 
    {
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
        }
    }

    private int TotalShots = 0;

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

        // Camera Recoil
        Recoil_Script.RecoilFire();

        // Wait fire rate
        Invoke("ResetShot", fireRate);
        bulletsLeft--;
        bulletsShot--;

        TotalShots++;
        Debug.Log("Total Shots: " + TotalShots);

        // Recurse if it is a burst gun
        if (bulletsShot > 0 && bulletsLeft > 0) 
        {
            Invoke("Shoot", timeBetweenShots);
        }
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