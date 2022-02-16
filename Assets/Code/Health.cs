using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 1;
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Damage");
        if (health <= 0)
        {
            Destroy(gameObject);
        }   
    }

    // Update is called once per frame
}
