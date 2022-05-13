using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDespawn : MonoBehaviour
{
    float timer = 1.0f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
