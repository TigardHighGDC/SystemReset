using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShooterMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public Rigidbody rb;
    float rotation;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float line = Mathf.Sqrt(Mathf.Pow(transform.position[0] - player.transform.position[0], 2) + Mathf.Pow(transform.position[1] - player.transform.position[1], 2) + Mathf.Pow(transform.position[2] - player.transform.position[2], 2));
        if (line < 14.0f)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            Debug.Log(Random.Range(1,100000));
            rotation = Mathf.Atan2(transform.position[0]-player.transform.position[0], transform.position[2]-player.transform.position[2]);
            agent.Move(new Vector3(Mathf.Sin(rotation), 0, Mathf.Cos(rotation))*Time.deltaTime*6f);
        }
        else
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
            agent.SetDestination(player.transform.position);   
        }
        
    }
}
