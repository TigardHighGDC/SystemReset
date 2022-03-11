using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public class AnkleBiterControl : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update

    public void ReCalc()
    {
        float total;
        int ankleBiter = 0;
        float[] positions;
        ankleBiter = 0;
        List<GameObject> bitersArr = new List<GameObject>();
        foreach (GameObject biter in GameObject.FindGameObjectsWithTag("ankleBiter"))
        {
            bitersArr.Add(biter);
            ankleBiter += 1;
        }
        positions = new float[ankleBiter];

        for (int i = 0; i < ankleBiter; i++)
        {
            float angle = i * Mathf.PI*2f / ankleBiter;
            positions[i] = angle;
        }

        float amount = 0.0f;
        float[] enemiesRad = new float[ankleBiter];
        int[] enemiesPos = new int[ankleBiter];

        float line;
        float line2;
        float mean = 0;

        Dictionary<float, int> enemPosSort = new Dictionary<float, int>();
        Vector3 dot;

        for (int i = 0; i < ankleBiter; i++)
        {
            //Finds radians and stores in enemiesRad
            line = Mathf.Sqrt(Mathf.Pow(bitersArr[i].transform.position[0] - player.transform.position[0], 2) + Mathf.Pow(bitersArr[i].transform.position[2] - player.transform.position[2], 2));
            dot = player.transform.position;
            dot[0] += Mathf.Cos(0.0f)*line;
            dot[2] += Mathf.Sin(0.0f)*line;
            line2 = Mathf.Sqrt(Mathf.Pow(bitersArr[i].transform.position[0] - dot[0], 2) + Mathf.Pow(bitersArr[i].transform.position[2] - dot[2], 2));

            enemiesRad[i] = Mathf.Pow(line2, 2) - Mathf.Pow(line,2) - Mathf.Pow(line,2);
            enemiesRad[i] = enemiesRad[i] / (line * line * -2);
            enemiesRad[i] = Mathf.Acos(enemiesRad[i]);
            enemPosSort[enemiesRad[i]] = i;
            mean += enemiesRad[i];
        }
        mean = mean / ankleBiter;
        int start = 0;
        total = 100000.0f;
        Debug.Log(mean);
        Array.Sort(enemiesRad);
        //Finds numbers closest to mean
        for (int i = 0; i < ankleBiter; i++)
        {
            if (Mathf.Abs(mean - ankleBiter) < total)
            {
                total = Mathf.Abs(mean - ankleBiter);
                start = i;
            }
        }
        //Goes through sorted enemiesRad and stores values of enemy that would follow that side
        int track = 0;
        for (int i = start; i < ankleBiter; i++)
        {
            enemiesPos[track] = enemPosSort[enemiesRad[i]];
            track += 1;

        }
        for (int i = 0; i < start; i++)
        {
            enemiesPos[track] = enemPosSort[enemiesRad[i]];
            track += 1;
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < enemiesPos.Length; i++)
        {
            sb.Append(enemiesPos[i].ToString());
            sb.Append("\t");
        }
        string s = sb.ToString();
        Debug.Log(s);

    }

    // Update is called once per frame
    void Update()
    {
        ReCalc();
    }
}
