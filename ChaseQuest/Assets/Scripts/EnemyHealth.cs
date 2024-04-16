using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Vida máxima do inimigo
    public int currentHealth; // Vida atual do inimigo
    private bool damaged; // Indica se o inimigo já foi danificado

    private float damageCooldown = 0.25f; // Tempo de recarga para permitir novo dano
    private float cooldownTimer; // Temporizador para controlar o tempo de recarga

    private Knockback knockback; // Referência ao componente Knockback

    private void Awake(){
        knockback = GetComponent<Knockback>();
    }
    private void Start()
    {
        currentHealth = maxHealth; // Configura a vida atual para a vida máxima no início
        cooldownTimer = damageCooldown; // Configura o temporizador para o tempo de recarga inicial
    }

    private void Update()
    {
        // Atualiza o temporizador de recarga
        if (damaged)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                damaged = false;
                cooldownTimer = damageCooldown; // Reinicia o temporizador
            }
        }
    }

    // // Método chamado quando este objeto colide com outro objeto que possui um Collider2D
    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     // Verifica se o objeto com o qual colidimos tem uma "tag" específica (você pode configurar tags nos objetos no Unity Editor)
    //     if (collision.gameObject.CompareTag("PlayerSword") && !damaged)
    //     {
    //         // Reduz a vida do inimigo (você pode ajustar isso conforme necessário)
    //         TakeDamage(25); // Reduz 10 de vida quando a espada do jogador colide

    //         damaged = true; // Marca o inimigo como danificado
    //     }
    // }

    // Método para reduzir a vida do inimigo
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduz a vida atual pelo valor do dano
        knockback.GetKnockedBack(PlayerController.instance.transform, 10f); // Aplica o knockback no inimigo
        // Verifica se a vida atual é menor ou igual a zero, indicando que o inimigo foi derrotado
        if (currentHealth <= 0)
        {
            Die(); // Chama o método de morte do inimigo
        }
    }

    // Método chamado quando o inimigo é derrotado
    private void Die()
    {
        // Aqui você pode adicionar qualquer lógica que desejar para quando o inimigo for derrotado
        Debug.Log("O inimigo foi derrotado!");

        // Por exemplo, você pode desativar o GameObject do inimigo quando ele morrer
        gameObject.SetActive(false);
    }
}
