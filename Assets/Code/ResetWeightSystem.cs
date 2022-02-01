using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetWeightSystem : MonoBehaviour
{
    public GameObject reset;
    // Start is called before the first frame update
    void Start()
    {
        reset.GetComponent<WeightSystem>().Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
