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
public class Rocket : MonoBehaviour
{
    public GameObject explosionParticle;
    public Transform camXRotation;
    public Rigidbody rb3d;
    public float speed;
    public float radius = 5.0F;
    public float power = 10.0F;

    void Start()
    {
        rb3d = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 direction = new Vector3(0, -1, 0) * Time.deltaTime *speed;
        direction = transform.worldToLocalMatrix.inverse * direction;
        rb3d.MovePosition(transform.position + direction);
    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
        Instantiate(explosionParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
