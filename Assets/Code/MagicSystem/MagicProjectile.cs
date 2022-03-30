using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicProjectile : MonoBehaviour
{
    public float damage;
    public float fireDamage;
    public float homingStrength;
    public float lightningStrength;
    public float speed;
    public float chaos;
    float chaosTimer = 0.5f;
    Vector3 direction;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (chaosTimer > 0.0f)
        {
            chaosTimer -= Time.deltaTime;
            direction = new Vector3(0,-1, 0) * Time.deltaTime * speed;
        }
        else
        {
            direction = new Vector3(Random.Range(-chaos, chaos),-1, Random.Range(-chaos, chaos)) * Time.deltaTime * speed;
            chaosTimer = 0.5f;
        }
        
        direction = transform.worldToLocalMatrix.inverse * direction;
        rb.MovePosition(transform.position + direction);
        chaosTimer = 0.5f;
    }
}
