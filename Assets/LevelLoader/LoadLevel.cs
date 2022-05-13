using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AcrossSceneData;

public class LoadLevel : MonoBehaviour
{
    void OnTriggerEnter(Collider collide)
    {
        Debug.Log(collide);
        if (collide.gameObject.tag == "Player" && GameObject.FindGameObjectsWithTag("ankleBiter").Length == 0 && GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            int index = AcrossSceneData.nonPick;
            while (index == AcrossSceneData.nonPick)
            {
                index = Random.Range(0, AcrossSceneData.Levels.Length);
            }
            AcrossSceneData.nonPick = index;
            AcrossSceneData.levelsComleted += 1;
            Debug.Log(index);
            SceneManager.LoadScene("Assets/Scenes/Level/"+AcrossSceneData.Levels[index]+".unity");

        }
    }
}
