using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb3d;
    public float speed;
    public GameObject weight;
    
    float horizontal;
    float vertical;
    float timer = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb3d = GetComponent<Rigidbody>();
        horizontal = Random.Range(-1.0f, 1.0f);
        vertical = Random.Range(-1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direction = new Vector3(horizontal,-1, vertical) * Time.deltaTime * speed;
        direction = transform.worldToLocalMatrix.inverse * direction;
        rb3d.MovePosition(transform.position + direction);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }


    }
    
    void OnTriggerEnter(Collider collision)
    {
        weight.GetComponent<WeightSystem>().straight += 1;
        Destroy(gameObject);
    }
}
