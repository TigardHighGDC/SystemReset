using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSounds : MonoBehaviour
{
    Vector3 testCase;
    AudioSource m_MyAudioSource;
    bool isGrounded;
    bool GroundCheck()
    {
	RaycastHit hit;
	float distance = 2;
	Vector3 dir = new Vector3(0, -1);

	if(Physics.Raycast(transform.position, dir, out hit, distance))
	{
		return true;
	}
	else
	{
		return false;
	}
    }

    void Start()
    {
        testCase = new Vector3(0.0f,0.0f,0.0f);
        m_MyAudioSource = GetComponent<AudioSource>();
        m_MyAudioSource.volume = 0.5f;
    }

    void Update()
    {
        if(m_MyAudioSource.isPlaying != true)
        {
            m_MyAudioSource.Play();
        }
               
        if (m_MyAudioSource.isPlaying == true && (GroundCheck() == false || testCase == new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"))))
        {
            if (m_MyAudioSource.volume > 0.0f)
            {
                m_MyAudioSource.volume = m_MyAudioSource.volume - 0.05f;
            }
        }   

        else if (GroundCheck() == true) 
        {
            if (m_MyAudioSource.volume < 0.5f)
            {
                m_MyAudioSource.volume = m_MyAudioSource.volume + 0.05f;
            }
            
        } 
    }
}
