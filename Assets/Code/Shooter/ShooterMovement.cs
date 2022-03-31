using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShooterMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    // Start is called before the first frame update
    int Distance()
    {
        float line = Mathf.Sqrt(Mathf.Pow(transform.position[0] - player.transform.position[0], 2) + Mathf.Pow(transform.position[2] - player.transform.position[2], 2));
        if (line > 20.0f)
        {
            return 0;
        }
        else if (line > 10.0f)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }  
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(Distance())
        {
            case 0:
                agent.SetDestination(player.transform.position);
                break;
            case 1:
                break;
            default:
                break;
        }
        
    }
}
