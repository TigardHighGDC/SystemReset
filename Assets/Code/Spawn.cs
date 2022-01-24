using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject bullet;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0.0f)
        {
            time = 1.0f;
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
