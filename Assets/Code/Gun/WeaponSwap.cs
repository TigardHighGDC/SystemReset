using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Gun;

public class WeaponSwap : MonoBehaviour
{
    public GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Gun.select = 1;
        }
        else if  (Input.GetKey(KeyCode.Alpha2))
        {
            Gun.select = 2;
        }

        if (Gun.select == 1)
        {
            weapon.GetComponent<basicShoot>().spread = 5.0f;
        }
        else if (Gun.select == 2)
        {

        }
        Debug.Log(weapon.GetComponent<basicShoot>().spread);

        
    }
}
