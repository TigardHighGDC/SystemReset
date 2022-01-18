using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{ 
    void OnTriggerEnter(Collider collide)
    {
        Destroy(gameObject);
    }

}
