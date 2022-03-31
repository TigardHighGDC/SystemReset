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
    List<GameObject> enemiesArr = new List<GameObject>();
    int closest = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (homingStrength > 0.0f)
        {
            float distance = 100000000000.0f;
            foreach (GameObject biter in GameObject.FindGameObjectsWithTag("ankleBiter"))
            {
                enemiesArr.Add(biter);
            }
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
            {
                enemiesArr.Add(enemy);
            }
            for (int i = 0; i < enemiesArr.Count; i++)
            {
                if (Mathf.Sqrt(Mathf.Pow(enemiesArr[i].transform.position[0]-transform.position[0], 2) + Mathf.Pow(enemiesArr[i].transform.position[2]-transform.position[2], 2)) < distance)
                {
                    distance = Mathf.Sqrt(Mathf.Pow(enemiesArr[i].transform.position[0]-transform.position[0], 2) + Mathf.Pow(enemiesArr[i].transform.position[2]-transform.position[2], 2));
                    closest = i;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (homingStrength > 0.0f)
        {
            direction = Vector3.RotateTowards(transform.forward, enemiesArr[closest].transform.position - transform.position, homingStrength, 0.0f)* Time.deltaTime * speed;;
        }
        else
        {
            direction = transform.forward * Time.deltaTime * speed;
        }

        
        //direction = transform.worldToLocalMatrix.inverse * direction;

        
        rb.MovePosition(transform.position + direction);
        chaosTimer = 0.5f;
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "enemy" || collision.tag == "ankleBiter" || collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
        
    }
}
