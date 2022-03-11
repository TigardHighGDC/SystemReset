using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

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
        List<Vector3> bitersArr = new List<Vector3>();
        foreach (GameObject biter in GameObject.FindGameObjectsWithTag("ankleBiter"))
        {
            bitersArr.Add(biter.transform.position);
            ankleBiter += 1;
        }
        positions = new float[ankleBiter];

        for (int i = 0; i < ankleBiter; i++)
        {
            float angle = i * Mathf.PI*2f / ankleBiter;
            positions[i] = angle;
        }

        float amount = 0.0f;
        int[] enemiesPos = new int[ankleBiter];
        float line = 0.0f;
        float line2 = 0.0f;
        for (int i = 0; i < ankleBiter; i++)
        {
            total = 100000000000.0f;
            for (int u = 0; u < ankleBiter; u++)
            {
                Vector3 arcCircle = player.transform.position;
                line = Mathf.Sqrt(Mathf.Pow(player.transform.position[0] - bitersArr[u][0], 2) + Mathf.Pow(player.transform.position[2] - bitersArr[u][2], 2));
                arcCircle[0] += Mathf.Cos(positions[i]) * line;
                arcCircle[2] += Mathf.Sin(positions[i]) * line;
                amount =  Mathf.Sqrt(Mathf.Pow(arcCircle[0] - bitersArr[u][0], 2) + Mathf.Pow(arcCircle[2] - bitersArr[u][2], 2)) / line;
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
