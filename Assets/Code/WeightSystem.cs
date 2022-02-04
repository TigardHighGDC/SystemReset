using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightSystem : MonoBehaviour
{
    public float straight = 10.0f;
    public float slight = 10.0f;
    public float heavy = 250.0f;
    public int Pick()
    {
        float total = straight+slight+heavy + 1.5f;
        float straightProb = (straight + 0.5f) / total;
        float slightProb = (slight+straight + 1.0f) / total;
        float r = Random.value;

        if (r < straightProb)
        {
            return 0;
        }   
        else if (r < slightProb)
        {
            return 1;
        }
        else
        {
            return 2; 
        }      
    }
    public void Add(int add)
    {
        switch(add)
        {
            case 0:
                straight += 1.0f;
                break;
            case 1:
                slight += 1.0f;
                break;
            default:
                heavy += 1.0f;
                break;
        }
    }
    public void Divide(int divide)
    { 
        
        straight /= 1.001f;
        slight /= 1.001f;
        heavy /= 1.001f;
    }
    
    public void Reset()
    {
        straight = 10.0f;
        slight = 10.0f;
        heavy = 50.0f;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
