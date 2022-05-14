using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorChange : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        SceneManager.LoadScene ("Scenes/Level/Level0");
    }
}
