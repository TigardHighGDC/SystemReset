using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float damage = 10f;
    public float range = 30f;

    public Camera fpsCam;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            shootGun();
        }
    }

    void shootGun() 
    {
        RaycastHit hit;
        Physics.Raycast(
            fpsCam.transform.position,
            fpsCam.transform.forward,
            out hit,
            range);
    }
}
