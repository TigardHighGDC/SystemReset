using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnkleBiter : MonoBehaviour
{
    public GameObject player;
    public GameObject unkleBiter;
    public Rigidbody movement;
    float angle;
    float timer = 5.0f;
    float pause = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0.0f)
        {
            angle = Mathf.Atan2(unkleBiter.transform.position[0]-player.transform.position[0], unkleBiter.transform.position[2]-player.transform.position[2]);
            movement.rotation = Quaternion.Euler(new Vector3(0,angle*(180/Mathf.PI),0));
            timer -= Time.deltaTime;
        }
        else
        {
            if (pause > 0.0f)
            {
                pause -= Time.deltaTime;
            }
            else
            {
                movement.MovePosition(transform.position + new Vector3(-20.0f * Mathf.Sin(angle), 0, -20.0f * Mathf.Cos(angle)) * Time.deltaTime);
            }
        }

        
    }
    void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.tag == "Wall")
        {
            timer = 5.0f;
            pause = 0.75f;
        }
    }
}
