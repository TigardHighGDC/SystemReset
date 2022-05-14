using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadSound : MonoBehaviour
{

    AudioSource m_MyAudioSource;

    void Start()
    {
        m_MyAudioSource.playOnAwake = false;
        m_MyAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown("r") && m_MyAudioSource.isPlaying != true) 
        {
            m_MyAudioSource.Play();
        }      
    }
}
