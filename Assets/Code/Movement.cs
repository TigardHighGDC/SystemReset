/*
 *   Copyright 2022 TigardHighGDC
 *
 *   Licensed under the Apache License, Version 2.0 (the "License");
 *   you may not use this file except in compliance with the License.
 *   You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 *   Unless required by applicable law or agreed to in writing, software
 *   distributed under the License is distributed on an "AS IS" BASIS,
 *   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *   See the License for the specific language governing permissions and
 *   limitations under the License.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb3d;
    public float speed;
    public float thrust;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0,
                                    Input.GetAxisRaw("Vertical"))
                            .normalized *speed *Time.deltaTime;
        input = transform.worldToLocalMatrix.inverse * input;
        rb3d.MovePosition(transform.position + input);

        if (Input.GetButton("Jump") && rb3d.velocity.y > -0.005 &&
            rb3d.velocity.y < 0.005 && time < 0.0f)
        {
            rb3d.AddForce(new Vector3(0, thrust, 0));
            time = 0.1f;
        }
        time -= Time.deltaTime;
    }
}
