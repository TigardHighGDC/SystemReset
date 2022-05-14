using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShoot : MonoBehaviour
{
    public int shotgun = 8;
    public float maxSpread;
    float shotgunSpread;
    public GameObject bullet;
    public Animation animation;
    GameObject magic;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        shotgunSpread  = maxSpread;
        //animation.Play("Hand_Final");
        if(Input.GetKeyDown(KeyCode.E))
        {
            shotgun = 6;       
        }
        else
        {
            shotgun = 0;
        }

        if (shotgun > 0)
        {
            for (int i = 1; i <= shotgun; i++)
            {
                magic = Instantiate(bullet, transform.position, transform.rotation);
                magic.transform.Rotate(Random.Range(0.0f, shotgunSpread/i), Random.Range(0.0f, shotgunSpread/i), 0.0f);
                magic.GetComponent<MagicProjectile>().damage = 4.0f;
                magic.GetComponent<MagicProjectile>().chaos = 5.0f;
                magic.GetComponent<MagicProjectile>().speed = 50f;
                magic.GetComponent<MagicProjectile>().size = 0.2f;
                magic.GetComponent<MagicProjectile>().homingStrength = 0.0f;
                magic = Instantiate(bullet, transform.position, transform.rotation);
                magic.GetComponent<MagicProjectile>().damage = 4.0f;
                magic.GetComponent<MagicProjectile>().chaos = 5.0f;
                magic.GetComponent<MagicProjectile>().speed = 50f;
                magic.GetComponent<MagicProjectile>().size = 0.2f;
                magic.GetComponent<MagicProjectile>().homingStrength = 0.0f;
                magic.transform.Rotate(Random.Range(0.0f, shotgunSpread/i), Random.Range(-shotgunSpread/i, 0.0f), 0);
                magic = Instantiate(bullet, transform.position, transform.rotation);
                magic.transform.Rotate(Random.Range(-shotgunSpread/i, 0.0f), Random.Range(0.0f, shotgunSpread/i), 0);
                magic.GetComponent<MagicProjectile>().damage = 4.0f;
                magic.GetComponent<MagicProjectile>().chaos = 5.0f;
                magic.GetComponent<MagicProjectile>().speed = 50f;
                magic.GetComponent<MagicProjectile>().size = 0.2f;
                magic.GetComponent<MagicProjectile>().homingStrength = 0.0f;
                magic = Instantiate(bullet, transform.position, transform.rotation);
                magic.GetComponent<MagicProjectile>().damage = 4.0f;
                magic.GetComponent<MagicProjectile>().chaos = 5.0f;
                magic.GetComponent<MagicProjectile>().speed = 50f;
                magic.GetComponent<MagicProjectile>().size = 0.2f;
                magic.GetComponent<MagicProjectile>().homingStrength = 0.0f;
                magic.transform.Rotate(Random.Range(-shotgunSpread/i,0), Random.Range(-shotgunSpread/i, 0), 0);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                magic = Instantiate(bullet, transform.position, transform.rotation);
                magic.GetComponent<MagicProjectile>().damage = 20.0f;
                magic.GetComponent<MagicProjectile>().chaos = 0f;
                magic.GetComponent<MagicProjectile>().speed = 20f;
                magic.GetComponent<MagicProjectile>().size = 0.5f;
                magic.GetComponent<MagicProjectile>().homingStrength = 8.0f;
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                magic = Instantiate(bullet, transform.position, transform.rotation);
                magic.GetComponent<MagicProjectile>().damage = 150.0f;
                magic.GetComponent<MagicProjectile>().chaos = 0f;
                magic.GetComponent<MagicProjectile>().speed = 5f;
                magic.GetComponent<MagicProjectile>().size = 1.5f;
                magic.GetComponent<MagicProjectile>().homingStrength = 0f;

            }
        }
            
        
        
    }
}
