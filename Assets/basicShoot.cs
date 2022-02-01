using UnityEngine;

public class basicShoot : MonoBehaviour
{
    // Gun stats
    public int damage = 10;
    public float timeBetweenShots = 0.5f, spread = 0.0f, range = 1000000.0f, reloadTime = 2.0f, fireRate = 0.2f;
    public int magSize = 10, shotsPerTap = 1;
    public bool allowButtonHold = true;

    private int bulletsLeft;
    private bool shooting = false, readyToShoot = true, reloading = false;

    // Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    private LayerMask whatIsEnemy;

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
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magSize && !reloading)
            Reload();

        // Shoot call
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0) {
            Shoot();
            Debug.Log("This is a shot");
        }
    }

    private void Shoot() {
        readyToShoot = false;
        bulletsLeft--;

        // RayCast
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out rayHit, range, whatIsEnemy)) {
            // Console log
            Debug.Log(rayHit.collider.name);

            // Obj needs to contain a function called 'TakeDamage' that takes an int as damage
            rayHit.collider.GetComponent<Cannon>().TakeDamage(damage);
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
