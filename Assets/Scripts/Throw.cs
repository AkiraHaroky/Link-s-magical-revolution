using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] private GameObject stonePrefab;
    [SerializeField] private GameObject stone_4;
    [SerializeField] private GameObject stone_3;
    [SerializeField] private GameObject stone_2;
    [SerializeField] private GameObject stone_1;
    [SerializeField] private GameObject stone_0;
    private float throwForce = 10f;
    private float gravityScale = 1f;

    private bool isThrowing = false;
    public bool opportunity = true;
    private float throwTime = 0f;
    private Vector2 touchStartPosition;
    private int throwsRemaining = 4;

    void Update()
    {
        if (Input.touchCount > 0 && throwsRemaining > 0 && opportunity == true)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isThrowing = true;
                throwTime = 0f;
                touchStartPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                if (isThrowing)
                {
                    throwTime += Time.deltaTime;
                }
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                if (isThrowing)
                {
                    ThrowStoneTo(touch.position);
                    throwsRemaining--;
                    isThrowing = false;

                    switch(throwsRemaining)
                    {
                        case 3: 
                            stone_4.SetActive(false);
                            stone_3.SetActive(true);
                            break;
                        case 2: 
                            stone_3.SetActive(false);
                            stone_2.SetActive(true);
                            break;                    
                        case 1: 
                            stone_2.SetActive(false);
                            stone_1.SetActive(true);
                            break;
                        case 0: 
                            stone_1.SetActive(false);
                            stone_0.SetActive(true);
                            break;
                    }
                }
            }
        }
    }

    void ThrowStoneTo(Vector2 targetScreenPosition)
    {
        Vector3 targetWorldPosition = Camera.main.ScreenToWorldPoint(targetScreenPosition);
        targetWorldPosition.z = 0;

        Vector2 direction = (Vector2)targetWorldPosition - (Vector2)transform.position;
        direction.Normalize();

        float throwDistance = throwForce * throwTime;
        Vector2 velocity = direction * throwDistance;

        GameObject stone = Instantiate(stonePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = stone.GetComponent<Rigidbody2D>();

        rb.velocity = velocity;
        rb.gravityScale = gravityScale;
    }
}
