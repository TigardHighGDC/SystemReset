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

using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float damage = 10f;
    public float range = 30f;

    public Camera fpsCam;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            shootGun();
        }
    }

    void shootGun() 
    {
        RaycastHit hit;
        Physics.Raycast(
            fpsCam.transform.position,
            fpsCam.transform.forward,
            out hit,
            range);
    }
}
