using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class AnkleBiterControl : MonoBehaviour
{
    public GameObject player;
    public int ankleBiter;
    Vector3[] positions;
    List<Vector3> bitersArr = new List<Vector3>();
    // Start is called before the first frame update
    float total = 1000000000000000.0f;

    public void ReCalc()
    {
        ankleBiter = 0;
        foreach (GameObject biter in GameObject.FindGameObjectsWithTag("ankleBiter"))
        {
            bitersArr.Add(biter.transform.position);
            ankleBiter += 1;
        }
        positions = new Vector3[ankleBiter];

        for (int i = 0; i < ankleBiter; i++)
        {
            float angle = i * Mathf.PI*2f / ankleBiter;
            positions[i] = player.transform.position + new Vector3(Mathf.Cos(angle)*100, 0.0f, Mathf.Sin(angle)*100);
        }
        float amount = 0.0f;
        int[] enemiesPos = new int[ankleBiter];
        for (int i = 0; i < ankleBiter; i++)
        {
            total = 100000000000.0f;
            for (int u = 0; u < ankleBiter; u++)
            {
                //Line defined by two points
                //enemy 0
                //positions 1
                //player 2
                amount = Mathf.Abs((player.transform.position[0] - positions[i][0])*(positions[i][2]-bitersArr[u][2]) - (positions[i][0]-bitersArr[u][0])*(player.transform.position[2]-positions[i][2])) / Mathf.Sqrt(Mathf.Pow(player.transform.position[0]-positions[i][0], 2) + Mathf.Pow(player.transform.position[2]-positions[i][2], 2));
                Debug.Log(amount);
                if (amount < total)
                {
                    total = amount;
                    enemiesPos[i] = u;
                }
            }    
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
