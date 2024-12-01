using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAttack : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public Animator animator;
    public float attackInterval = 3f;
    public float arrowSpeed = 10f;
    public GameObject player; // ссылка на игрока
    public Health healthGoblin; // ссылка на здоровье гоблина


    private float nextAttackTime;

    void Start()
    {
        nextAttackTime = Time.time + attackInterval;
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackInterval;
        }
    }

    void Attack()
    {
        if (healthGoblin.isDead == true)
        {
            animator.SetTrigger("Attack"); // запускаем анимацию атаки

            // Создаем стрелу
            GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
            Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();

            // Находим направление к игроку
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.velocity = direction * arrowSpeed;
        }
        
    }


}
