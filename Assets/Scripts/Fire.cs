using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
   [SerializeField] private GameObject bigFire;
   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fire"))
        {
            bigFire.SetActive(true);
            Destroy(gameObject);
        }
    } 
}
