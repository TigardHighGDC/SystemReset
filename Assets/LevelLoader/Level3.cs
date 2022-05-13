using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    public GameObject ankleBiter;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4+AcrossSceneData.levelsComleted; i++)
        {
            Instantiate(ankleBiter, new Vector3(Random.Range(1, 37), 2, Random.Range(-39, -5)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
