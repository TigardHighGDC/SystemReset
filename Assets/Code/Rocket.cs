using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Rocket : MonoBehaviour
{ 
    public GameObject explosionParticle;
    public Transform camXRotation;
    public Rigidbody rb3d;
    public float speed;
    public float radius = 5.0F;
    public float power = 10.0F;
    

    void Start()
    {
        rb3d = GetComponent<Rigidbody>();
    }

    void Update()
    {  
        Vector3 direction = new Vector3(0, -1, 0) * Time.deltaTime * speed;
        direction = transform.worldToLocalMatrix.inverse * direction;
        rb3d.MovePosition(transform.position + direction);

    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
         foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
        Instantiate(explosionParticle, transform.position, transform.rotation);
        Destroy(gameObject);        
    }
}
