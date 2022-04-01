using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShooterMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public Rigidbody rb;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float line = Mathf.Sqrt(Mathf.Pow(transform.position[0] - player.transform.position[0], 2) + Mathf.Pow(transform.position[2] - player.transform.position[2], 2));
        if (line < 10.0f)
        {
            rb.MovePosition(transform.position + (-transform.forward*Time.deltaTime*10.0f));
        }
        agent.SetDestination(player.transform.position);
        
    }
}
