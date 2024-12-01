using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject health_f;
    [SerializeField] private GameObject health_m;
    [SerializeField] private GameObject health_s;
    private Animator animator;
    private int healthGoblin = 3;
    public bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead == true)
        {
            Invoke("DeathAnim",2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stone"))
        {
            healthGoblin--;
            if (healthGoblin == 2)
            {
                health_f.SetActive(false);
                health_m.SetActive(true);
            }

            if (healthGoblin == 1)
            {
                health_m.SetActive(false);
                health_s.SetActive(true);
            }
            //audioSource_Damage.Play();
            if (healthGoblin == 0)
            {
                GameObject.Find("Main Camera").GetComponent<Counter>().countDeath += 1;
                isDead = true;
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Death"))
        {
            if (isDead == false)
            {
                GameObject.Find("Main Camera").GetComponent<Counter>().countDeath += 1;
                isDead = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Safe"))
        { 
            animator.Play("Fear");
        }
    }


    void DeathAnim()
    {
        health_f.SetActive(false);
        health_m.SetActive(false);
        health_s.SetActive(false);
        animator.Play("Death");
    }
}

