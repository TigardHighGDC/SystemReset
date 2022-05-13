using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnkleBiter : MonoBehaviour
{
    public GameObject player;
    public GameObject unkleBiter;
    Vector3 prev = new Vector3(1, 1, 1);
    public UnityEngine.AI.NavMeshAgent agent;
    float angle;
    float timer = 3.0f;
    float pause = 0.75f;
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0.0f)
        {
            angle = Mathf.Atan2(unkleBiter.transform.position[0] - player.transform.position[0], unkleBiter.transform.position[2] - player.transform.position[2]);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, angle * (180 / Mathf.PI), 0)), 100.0f * Time.deltaTime);
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
                agent.Move(new Vector3(-Mathf.Sin(transform.rotation.y * 2), 0, -Mathf.Cos(transform.rotation.y * 2)) * Time.deltaTime *speed);
                if ((transform.position - prev).magnitude < 0.2f)
                {
                    timer = 3.0f;
                    pause = 0.75f;
                }
                prev = transform.position;
            }
        }
    }
}
