using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetDelete : MonoBehaviour
{
      void OnTriggerEnter(Collider other)
      {
          if (other.tag == "Projectile")
          {
             Destroy(gameObject);
          }
      }
}
