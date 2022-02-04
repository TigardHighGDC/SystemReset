using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb3d;
    public float speed;
    //public WeightSystem data;
    
    float horizontal;
    float vertical;
    float timer = 10.0f;
    int value;
    // Start is called before the first frame update
    void Start()
    {
        value = weight.GetComponent<WeightSystem>().Pick();
        rb3d = GetComponent<Rigidbody>();
        switch(value)
        {
            case 0:
                horizontal = 0.0f;
                vertical = 0.0f;
                break;
            case 1:
                horizontal = Random.Range(-1.0f, 1.0f);
                vertical = 0.0f;
                break;
            default:
                horizontal = Random.Range(-2.0f, 2.0f);
                vertical = Random.Range(-1.0f, 1.0f);
                break;
        }
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
            weight.GetComponent<WeightSystem>().Divide(value);
            Destroy(gameObject);
        }


    }
    
    void OnCollisionEnter(Collider collision)
    {
        weight.GetComponent<WeightSystem>().Divide(value);
        if (collision.tag == "Player")
        {
            weight.GetComponent<WeightSystem>().Add(value);
        }
        
        Destroy(gameObject);
    }
}
