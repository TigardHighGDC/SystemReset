using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShoot : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject spell = Instantiate(bullet, transform.position, transform.rotation);
            //spell.GetComponent<MagicProjectile>().homingStrength = 0.10f;
        }
        
        
    }
}
