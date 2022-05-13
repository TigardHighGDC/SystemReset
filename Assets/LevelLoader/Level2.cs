using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    public GameObject ankleBiter;
    public GameObject Shooter;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 1+AcrossSceneData.levelsComleted/4; i++)
        {
            Instantiate(ankleBiter, new Vector3(Random.Range(1, 7), 22, Random.Range(-22, -13)), Quaternion.identity);
        }
        for (int i = 0; i < 1+AcrossSceneData.levelsComleted/3; i++)
        {
            Instantiate(ankleBiter, new Vector3(Random.Range(17, 23), 22, Random.Range(-10, 0)), Quaternion.identity);
        }
        for (int i = 0; i < 2+AcrossSceneData.levelsComleted/2; i++)
        {
            Instantiate(Shooter, new Vector3(Random.Range(1, 7), 22, Random.Range(-22, -13)), Quaternion.identity);
        }
        for (int i = 0; i < 2+AcrossSceneData.levelsComleted/2; i++)
        {
            Instantiate(Shooter, new Vector3(Random.Range(17, 23), 22, Random.Range(-10, 0)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
