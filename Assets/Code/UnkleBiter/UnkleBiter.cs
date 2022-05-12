using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnkleBiter : MonoBehaviour
{
    public GameObject player;
    public GameObject unkleBiter;
    Vector3 prev = new Vector3(1,1,1);
    public UnityEngine.AI.NavMeshAgent agent;
    float angle;
    float timer = 3.0f;
    float pause = 0.75f;
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0.0f)
        {
            angle = Mathf.Atan2(unkleBiter.transform.position[0] - player.transform.position[0], unkleBiter.transform.position[2] - player.transform.position[2]);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, angle * (180 / Mathf.PI), 0)), 50.0f * Time.deltaTime);
            Quaternion.Euler(new Vector3(0, angle * (180 / Mathf.PI), 0));
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
                agent.Move(new Vector3(-1*Mathf.Sin(transform.rotation[1]),0,-1*Mathf.Cos(transform.rotation[1])) * Time.deltaTime * speed);
                if ((transform.position - prev).magnitude < 0.05f)
                {
                    timer = 3.0f;
                    pause = 0.75f;
                }
                prev = transform.position;
            }
        }
    }
    void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag == "Wall")
        {
            timer = 5.0f;
            pause = 0.75f;
        }
    }
}
