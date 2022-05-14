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

public class RocketShoot : MonoBehaviour
{
    public GameObject Rocket;
    bool canJump;

    void Start()
    {
        canJump = true;
    }
    void Update()
    {
        if (Input.GetKeyDown("q"))
        //if(Input.GetMouseButtonDown(0))
        {
            if(canJump == true)
            {
                Instantiate(Rocket, transform.position, transform.rotation);
                canJump = false;
                Invoke("cooldown", 0.25f);
            }
        }
    }
    void cooldown()
    {
        canJump = true;
    }
}
