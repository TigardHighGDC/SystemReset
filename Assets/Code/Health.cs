using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100.0f;
    public float frost;
    public float fire;
    public float lightning;
    
    // Start is called before the first frame update
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }   
    }

    // Update is called once per frame
}
