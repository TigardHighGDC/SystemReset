using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject bullet;
    public float time;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            timer = time;
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
