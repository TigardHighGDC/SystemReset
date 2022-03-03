using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnkleBiterControl : MonoBehaviour
{
    public GameObject player;
    public int ankleBiter;
    Vector3[] positions;
    List<GameObject> bitersArr = new List<GameObject>();
    // Start is called before the first frame update
    public void ReCalc()
    {
        ankleBiter = 0;
        foreach (GameObject biter in GameObject.FindGameObjectsWithTag("ankleBiter"))
        {
            bitersArr.Add(biter);
            ankleBiter += 1;
        }
        positions = new Vector3[ankleBiter];

        for (int i = 0; i < ankleBiter; i++)
        {
            float angle = i * Mathf.PI*2f / ankleBiter;
            positions[i] = player.transform.position + new Vector3(Mathf.Cos(angle), 0.0f, Mathf.Sin(angle));
        }
        //Debug.Log(positions);
    }

    // Update is called once per frame
    void Update()
    {
        ReCalc();
    }
}
