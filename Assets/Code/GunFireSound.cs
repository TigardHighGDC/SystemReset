using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireSound : MonoBehaviour
{

    AudioSource m_MyAudioSource;

    void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
        m_MyAudioSource.loop = true;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && m_MyAudioSource.isPlaying != true)
        {
            m_MyAudioSource.Play();
        }     
        else if(Input.GetKey(KeyCode.Mouse0) != true && m_MyAudioSource.isPlaying)
        {
            m_MyAudioSource.Stop();
        }
    }
}
