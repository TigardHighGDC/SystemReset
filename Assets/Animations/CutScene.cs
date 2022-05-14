using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    AudioSource m_MyAudioSource;
    public GameObject blackout;
    public AudioClip otherClip;
    int index;  
    void Start()
    {
        blackout.SetActive(false);
        m_MyAudioSource = GetComponent<AudioSource>();
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_MyAudioSource.isPlaying != true)
        {
        if (index == 0)
        {
            blackout.SetActive(true);
            GetComponent<AudioSource>().clip = otherClip;
            GetComponent<AudioSource>().Play();
            index = 1;
        }
        if (index == 1)
        {
            Invoke("sceneChange", 9.0f);
        }
        }
    }
        
void sceneChange()
        {
            SceneManager.LoadScene ("Scenes/Lab/Lab1");
        }
}
