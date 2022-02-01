using UnityEngine;

public class basicShoot : MonoBehaviour
{
    // Gun stats
    public int damage;
    public float timeBetweenShots, spread, range, reloadTime, fireRate;
    public int magSize, shotsPerTap;
    public bool allowButtonHold;

    private int bulletsLeft, bulletsShot;
    private bool shooting, readyToShoot, reloading;

    // Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    private void Awake() {
        bulletsLeft = magSize;
        readyToShoot = true;
    }

    // Once per frame update
    private void Update() {
        ThisInput();
    }

    private void ThisInput() {
        if (allowButtonHold)
            shooting = Input.GetKey(KeyCode.Mouse0);
        else
            shooting = Input.GetKeyDown(KeyCode.Mouse0);

        // 'R' is the reload button
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magSize && !reloading)
            Reload();

        // Shoot call
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
            Shoot();
    }

    private void Shoot() {
        readyToShoot = false;
        bulletsLeft--;

        // RayCast
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out rayHit, range, whatIsEnemy)) {
            // Console log
            Debug.Log(rayHit.collider.name);

            // Obj needs to contain a function called 'TakeDamage' that takes an int as damage
            rayHit.collider.GetComponent<shootingAi>().TakeDamage(damage);
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
    }
}
