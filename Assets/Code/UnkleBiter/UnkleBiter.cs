using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnkleBiter : MonoBehaviour
{
    public GameObject player;
    public GameObject unkleBiter;
    public Rigidbody movement;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angle = Mathf.Atan2(unkleBiter.transform.position[0]-player.transform.position[0], unkleBiter.transform.position[2]-player.transform.position[2]);
        movement.rotation = Quaternion.Euler(new Vector3(0,angle*180/Mathf.PI,0));
    }
}
