using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOne : MonoBehaviour
{
    public GameObject ankleBiter;
    public GameObject unkleBiter;
    public GameObject Shooter;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3+AcrossSceneData.levelsComleted/3; i++)
        {
            Instantiate(ankleBiter, new Vector3(Random.Range(10, 59), 4, Random.Range(-18, -11)), Quaternion.identity);
        }
        for (int i = 0; i < 1+AcrossSceneData.levelsComleted/4; i++)
        {
            Instantiate(unkleBiter, new Vector3(Random.Range(10, 59), 4, Random.Range(-18, -11)), Quaternion.identity);
        }
        for (int i = 0; i < 1+AcrossSceneData.levelsComleted/4; i++)
        {
            Instantiate(unkleBiter, new Vector3(Random.Range(10, 59), 1, Random.Range(-9, -3)), Quaternion.identity);
        }
        for (int i = 0; i < 1+AcrossSceneData.levelsComleted/4; i++)
        {
            Instantiate(unkleBiter, new Vector3(Random.Range(10, 59), 1, Random.Range(-28, -22)), Quaternion.identity);
        }
        for (int i = 0; i < 1+AcrossSceneData.levelsComleted/4; i++)
        {
            Instantiate(Shooter, new Vector3(Random.Range(10, 59), 4, Random.Range(-18, -11)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
