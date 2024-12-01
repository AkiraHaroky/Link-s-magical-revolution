using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;
    public int countDeath = 0;
    void Update()
    {
        Debug.Log(countDeath);
        if (countDeath >= 6)
        {
            dialogue.SetActive(true);
        }
        
    }
}
