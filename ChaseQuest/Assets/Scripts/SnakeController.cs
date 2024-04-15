using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float moveSpeedSnake = 3f;
    private Vector2 snakeDirection;
    private Rigidbody2D snakeRB;
    public DetectionController detectionArea;
    private SpriteRenderer spriteRenderer;

    public float knockbackForce = 5f;
    public float knockbackDuration = 0.20f;
    private bool isKnockback = false;
    private float knockbackTimer = 0f;

    void Start()
    {
        snakeRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }

  
    void Update()
    {
        snakeDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        if (!isKnockback && detectionArea.detectedObjs.Count > 0)
        {
            snakeDirection = (detectionArea.detectedObjs[0].transform.position - transform.position).normalized;
            snakeRB.MovePosition(snakeRB.position + snakeDirection * moveSpeedSnake * Time.fixedDeltaTime);

            if (snakeDirection.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }

        if (isKnockback)
        {
            snakeRB.AddForce(snakeDirection * knockbackForce, ForceMode2D.Impulse);

            knockbackTimer -= Time.fixedDeltaTime;

             if (knockbackTimer <= 0)
            {
                isKnockback = false;
            }
        }
    }

    public void Knockback(Vector2 direction)
    {
        isKnockback = true;
        knockbackTimer = knockbackDuration;
        snakeDirection = direction;
    }

    // Handle collision with sword
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerSword"))
        {
            // Initialize knockback
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            Knockback(knockbackDirection);
        }
    }
}
