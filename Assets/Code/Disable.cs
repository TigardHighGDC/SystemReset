using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    GameObject yourGameObject;

    void Awake()
    {
        yourGameObject = GameObject.Find("watermelongunheher");
    }

    void Update()
    {
        if (Input.GetKeyDown("o"))
            yourGameObject.SetActive(true);
        if (Input.GetKeyDown("p"))
            yourGameObject.SetActive(false);
    }
}
