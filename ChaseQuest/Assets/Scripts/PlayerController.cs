using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private Rigidbody2D playerRb;
    public float playerSpeed;
    private float playerInitialSpeed;
    public float playerStealthSpeed;
    public float playerRunSpeed;
    private Animator playerAnimator;
    private Vector2 playerDirection;
    private bool isAttack = false;

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
        PlayerRun();
        onAttack();
        
        if (isAttack)
        {
            playerAnimator.SetInteger("Movimento", 2);
        }
    }

    void FixedUpdate()
    {   
        playerRb.MovePosition(playerRb.position + playerDirection.normalized * playerSpeed * Time.fixedDeltaTime);
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

    void PlayerRun(){
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            playerSpeed = playerRunSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            playerSpeed = playerInitialSpeed;
        }
    }

    void onAttack(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isAttack = true;
            playerSpeed = 0;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isAttack = false;
            playerSpeed = playerInitialSpeed;
        }
    }
}