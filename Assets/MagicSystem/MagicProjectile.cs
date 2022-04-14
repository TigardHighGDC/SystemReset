using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MagicProjectile : MonoBehaviour
{
    public HashSet<string> breakables;
    public float damage;
    public float fireDamage;
    public float homingStrength;
    public float lightningStrength;
    public float speed;
    public float maxTime = 20.0f;
    public float chaos;
    public float size = 0.2f;
    
    float chaosTimer = 0.5f;
    Vector3 direction;
    public Rigidbody rb;
    List<GameObject> enemiesArr = new List<GameObject>();
    int closest = 0;
    // Start is called before the first frame update
    void Start()
    {
        breakables = new HashSet<string>();
        breakables.Add("enemy");
        breakables.Add("ankleBiter");
        breakables.Add("Wall");

        transform.localScale = new Vector3(size,size,size);
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
                if (Mathf.Sqrt(Mathf.Pow(enemiesArr[i].transform.position[0]-transform.position[0], 2) + Mathf.Pow(enemiesArr[i].transform.position[1]-transform.position[1], 2) + Mathf.Pow(enemiesArr[i].transform.position[2]-transform.position[2], 2)) < distance)
                {
                    distance = Mathf.Sqrt(Mathf.Pow(enemiesArr[i].transform.position[0]-transform.position[0], 2) + Mathf.Pow(enemiesArr[i].transform.position[1]-transform.position[1], 2) + Mathf.Pow(enemiesArr[i].transform.position[2]-transform.position[2], 2));
                    closest = i;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        maxTime -= Time.deltaTime;
        if (maxTime < 0.0f)
        {
            Destroy(gameObject);
        }

        if (homingStrength > 0.0f)
        {
            var lookRotation = Quaternion.LookRotation((enemiesArr[closest].transform.position - transform.position).normalized);
            rb.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * homingStrength);
            
        }

        if (chaos > 0.0f)
        {
            if (chaosTimer > 0.0f)
            {
                Vector3 randomDirection = new Vector3(Random.Range(-1.0f,1.0f), Random.Range(-1.0f,1.0f), Random.Range(-1.0f,1.0f));
                rb.MoveRotation(rb.rotation * Quaternion.Euler(randomDirection * chaos));
                chaosTimer -= Time.deltaTime;
            }
            else
            {
                chaosTimer -= Time.deltaTime;
            }   
        }
        direction = transform.forward * Time.deltaTime * speed;

        
        

        
        rb.MovePosition(transform.position + direction);
        chaosTimer = 0.5f;
    }
    void OnTriggerEnter(Collider collision)
    {
        if(breakables.Contains(collision.tag))
        {
            Destroy(gameObject);
        }
        
    }
}
