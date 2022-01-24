using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb3d;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb3d = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0,-1,0) * Time.deltaTime * speed;
        direction = transform.worldToLocalMatrix.inverse * direction;
        rb3d.MovePosition(transform.position + direction);
    }
    
    void OnTriggerEnter(Collider collision)
    {
        Destroy(gameObject);
    }
}
