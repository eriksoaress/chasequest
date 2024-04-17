using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public static PlayerController instance;
    private Rigidbody2D playerRb;
    public float playerSpeed;
    private float playerInitialSpeed;
    public float playerStealthSpeed;
    public float playerRunSpeed;
    private Animator playerAnimator;
    private Vector2 playerDirection;
    private bool isAttack = false;
    private float attackTimer = 0.25f; // Tempo de duração do ataque
    private float currentAttackTime = 0f; 
    private Knockback knockback;// Tempo atual de duração do ataque

    private void Awake()
    {
        instance = this;
        knockback = GetComponent<Knockback>();
    }

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
        }
        else
        {
            playerAnimator.SetInteger("Movimento", 0);
        }

        Flip();
        PlayerStealth();
        PlayerRun();
        onAttack();

        if (isAttack)
        {
            playerAnimator.SetInteger("Movimento", 2);
            currentAttackTime += Time.deltaTime;
            if (currentAttackTime >= attackTimer)
            {
                isAttack = false;
                currentAttackTime = 0f; // Reinicia o temporizador de ataque
                playerSpeed = playerInitialSpeed; // Restaura a velocidade do jogador
            }
        }
    }

    void FixedUpdate()
    {   
        if (knockback.gettingKnockedBack)
        {
            return;
        }
        playerRb.MovePosition(playerRb.position + playerDirection.normalized * playerSpeed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        if (playerDirection.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (playerDirection.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
    

    void PlayerStealth()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerSpeed = playerStealthSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerSpeed = playerInitialSpeed;
        }
    }

    void PlayerRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            playerSpeed = playerRunSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            playerSpeed = playerInitialSpeed;
        }
    }

    void onAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isAttack = true;
            playerSpeed = 0;
        }
    }
}
