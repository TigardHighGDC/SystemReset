using UnityEngine;

public class basicShoot : MonoBehaviour
{
    // Gun stats
    public int damage;
    public float timeBetweenShots, spread, reloadTime, fireRate, range;
    public int magSize, shotsPerTap;
    public bool allowButtonHold;

    private int bulletsLeft;
    private bool shooting = false, readyToShoot = true, reloading = false;

    // Reference
    public Camera fpsCam;
    //public Transform attackPoint;
    public RaycastHit rayHit;

    private void Awake() {
        bulletsLeft = magSize;
        readyToShoot = true;
    }

    // Once per frame update
    private void Update() {
        ThisInput();
    }

    private void ThisInput() {
        if (allowButtonHold) {
            shooting = Input.GetKey(KeyCode.Mouse0);
        } else {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        // 'R' is the reload button
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magSize && !reloading) {
            Reload();
            Debug.Log("Reloading...");
        }

        // Shoot call
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0) {
            Shoot();
            Debug.Log("This is a shot");
            Debug.Log(bulletsLeft);
        }
    }

    private void Shoot() {
        readyToShoot = false;
        bulletsLeft--;

        // Debug.Log(fpsCam.transform.position);
        // Debug.Log(fpsCam.transform.forward);
        // Debug.Log(rayHit);

        // RayCast
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out rayHit, range)) {
            // Console log
            if(rayHit.collider.tag == "enemy")
            {
                rayHit.collider.GetComponent<Health>().TakeDamage(damage);
            }
            // Obj needs to contain a function called 'TakeDamage' that takes an int as damage
        }

        // Wait fire rate
        Invoke("ResetShot", fireRate);
    }

    private void ResetShot() {
        readyToShoot = true;
    }

    private void Reload() {
        reloading = true;
        Invoke("FinishReload", reloadTime);
    }

    private void FinishReload() {
        bulletsLeft = magSize;
        reloading = false;
        Debug.Log("Done reloading...");
    }
}