using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private Rigidbody2D playerRb;
    public float playerSpeed;
    private float playerInitialSpeed;
    public float playerStealthSpeed;
    private Animator playerAnimator;
    private Vector2 playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerInitialSpeed = playerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (playerDirection.sqrMagnitude > 0)
        {
            playerAnimator.SetInteger("Movimento", 1);
        }else{
            playerAnimator.SetInteger("Movimento", 0);
        }

        Flip();
        PlayerStealth();
    }

    void FixedUpdate()
    {   
        playerRb.MovePosition(playerRb.position + playerDirection * playerSpeed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        if (playerDirection.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }else if (playerDirection.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
    

    void PlayerStealth(){
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerSpeed = playerStealthSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerSpeed = playerInitialSpeed;
        }
}
}