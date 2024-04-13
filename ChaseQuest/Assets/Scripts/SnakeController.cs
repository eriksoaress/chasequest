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

    // Start is called before the first frame update
    void Start()
    {
        snakeRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        snakeDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        if (detectionArea.detectedObjs.Count > 0)
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
    }
}
