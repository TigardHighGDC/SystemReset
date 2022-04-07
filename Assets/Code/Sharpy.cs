using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharpy : MonoBehaviour
{
    public GameObject player;
    public float speed=10.0f;
    public Rigidbody movement;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector3.RotateTowards(transform.forward, player.transform.position - transform.position, 10.0f, 0.0f) * Time.deltaTime * speed;
        movement.MovePosition(transform.position + direction); 
    }
}
