using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public float mouseSpeed;
    public Transform playerPos;

    float rotation = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed *Time.deltaTime;

        rotation -= mouseY;
        rotation = Mathf.Clamp(rotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotation, 0f, 0f);
        playerPos.Rotate(Vector3.up * mouseX);
    }

    public void RotatePlayerCamera(vector3 NewRotation) {
        playerPos.Rotate(NewRotation);
    }
}
