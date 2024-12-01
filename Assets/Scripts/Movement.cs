using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    private float speed = 4f;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        GameObject.Find("Link").GetComponent<Throw>().opportunity = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector2 movement = new Vector2(horizontal, vertical);

        rb.velocity = movement * speed;

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Speed", movement.magnitude);
    }
}
