using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShoot : MonoBehaviour
{
    public int shotgun = 8;
    public float maxSpread;
    float shotgunSpread;
    public GameObject bullet;
    GameObject spell;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shotgunSpread  = maxSpread;
        if (Input.GetButtonDown("Fire1"))
        {
            if (shotgun > 0)
            {
                for (int i = 1; i <= shotgun; i++)
                {
                    spell = Instantiate(bullet, transform.position, transform.rotation);
                    spell.transform.Rotate(Random.Range(0.0f, shotgunSpread/i), Random.Range(0.0f, shotgunSpread/i), 0.0f);
                    spell = Instantiate(bullet, transform.position, transform.rotation);
                    spell.transform.Rotate(Random.Range(0.0f, shotgunSpread/i), Random.Range(-shotgunSpread/i, 0.0f), 0);
                    spell = Instantiate(bullet, transform.position, transform.rotation);
                    spell.transform.Rotate(Random.Range(-shotgunSpread/i, 0.0f), Random.Range(0.0f, shotgunSpread/i), 0);
                    spell = Instantiate(bullet, transform.position, transform.rotation);
                    spell.transform.Rotate(Random.Range(-shotgunSpread/i,0), Random.Range(-shotgunSpread/i, 0), 0);
                }
                
            }
            else
            {
                spell = Instantiate(bullet, transform.position, transform.rotation);
            }
            
        }
        
        
    }
}
