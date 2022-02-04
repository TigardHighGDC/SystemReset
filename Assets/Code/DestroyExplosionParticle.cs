using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosionParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyObject", 3);
    }

    void destroyObject()
    {
        Destroy(gameObject);
    }
}
