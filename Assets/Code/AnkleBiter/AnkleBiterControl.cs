/*
 *   Copyright 2022 TigardHighGDC
 *
 *   Licensed under the Apache License, Version 2.0 (the "License");
 *   you may not use this file except in compliance with the License.
 *   You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 *   Unless required by applicable law or agreed to in writing, software
 *   distributed under the License is distributed on an "AS IS" BASIS,
 *   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *   See the License for the specific language governing permissions and
 *   limitations under the License.
 */

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
            float angle = (i * Mathf.PI * 2f) / ankleBiter;
            positions[i] = angle;
        }

        float[] enemiesRad = new float[ankleBiter];
        int[] enemiesPos = new int[ankleBiter];

        float line;
        float mean = 0;

        Dictionary<float, int> enemPosSort = new Dictionary<float, int>();

        for (int i = 0; i < ankleBiter; i++)
        {
            // Finds radians and stores in enemiesRad

            enemiesRad[i] = Mathf.Atan2(bitersArr[i].transform.position.x - player.transform.position.x, bitersArr[i].transform.position.z - player.transform.position.z);
            enemPosSort[enemiesRad[i]] = i;
            mean += enemiesRad[i];
        }
        mean = mean / ankleBiter;
        int start = 0;
        total = 100000.0f;
        // Finds numbers closest to mean
        for (int i = 0; i < ankleBiter; i++)
        {
            if (Mathf.Abs(mean - enemiesRad[i]) < total)
            {
                total = Mathf.Abs(mean - enemiesRad[i]);
                start = enemPosSort[enemiesRad[i]];
            }
        }
        // Goes through sorted enemiesRad and stores values of enemy that would
        // follow that side

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

        Vector3 pos;
        mean = 0.0f;

        for (int i = 0; i < ankleBiter; i++)
        {
            mean += Mathf.Sqrt(Mathf.Pow(bitersArr[enemiesPos[i]].transform.position[0] - player.transform.position[0], 2) + Mathf.Pow(bitersArr[enemiesPos[i]].transform.position[2] - player.transform.position[2], 2));
        }
        mean = mean / ankleBiter;
        for (int i = 0; i < ankleBiter; i++)
        {
            line = Mathf.Sqrt(Mathf.Pow(bitersArr[enemiesPos[i]].transform.position[0] - player.transform.position[0], 2) + Mathf.Pow(bitersArr[enemiesPos[i]].transform.position[2] - player.transform.position[2], 2));
            line = Mathf.Max(line / 1.6f, 1);
            pos = new Vector3(Mathf.Cos(positions[i]) * line, 0, Mathf.Sin(positions[i]) * line) + player.transform.position;
            bitersArr[enemiesPos[i]].GetComponent<AnkleBiterScript>().position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ReCalc();
    }
}
