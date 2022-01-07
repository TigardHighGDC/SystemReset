using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb3d;
    public float speed;
    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var camDeg = cam.rotation.y * 180;
        Debug.Log(camDeg);
        float x = 0.0f;
        float y = 0.0f;
        x += Mathf.Cos(camDeg+0) * Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        y += Mathf.Sin(camDeg + 0) * Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        x += Mathf.Cos(camDeg + 90) * Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        y = Mathf.Sin(camDeg + 90) * Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        Vector3 input = new Vector3(x, 0, y);
        rb3d.MovePosition(transform.position + input); 
    }
}
