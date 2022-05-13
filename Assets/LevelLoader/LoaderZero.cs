using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AcrossSceneData;

public class LoaderZero : MonoBehaviour
{
    public GameObject ankleBiter;
    public GameObject unkleBiter;
    public GameObject Shooter;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3+AcrossSceneData.levelsComleted/2; i++)
        {
            Instantiate(ankleBiter, new Vector3(Random.Range(-26, -2), -8, Random.Range(-17, 9)), Quaternion.identity);
        }
        for (int i = 0; i < 1+AcrossSceneData.levelsComleted/6; i++)
        {
            Instantiate(unkleBiter, new Vector3(Random.Range(-26, -2), -8, Random.Range(-17, 9)), Quaternion.identity);
        }
        for (int i = 0; i < 2+AcrossSceneData.levelsComleted/4; i++)
        {
            Instantiate(Shooter, new Vector3(Random.Range(-26, -2), -8, Random.Range(-17, 9)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
