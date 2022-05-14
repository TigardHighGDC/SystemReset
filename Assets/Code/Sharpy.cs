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

public class Sharpy : MonoBehaviour
{
    public GameObject player;
    public float speed = 10.0f;
    public Rigidbody movement;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector3.RotateTowards(transform.forward, player.transform.position - transform.position, 10.0f, 0.0f) * Time.deltaTime * speed;
        movement.MovePosition(transform.position + direction);
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            player.gameObject.GetComponent<playerHealth>().TakeDamage(15f);
        }
    }
}
