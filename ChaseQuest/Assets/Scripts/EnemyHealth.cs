using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Vida máxima do inimigo
    private int currentHealth; // Vida atual do inimigo

    private void Start()
    {
        currentHealth = maxHealth; // Configura a vida atual para a vida máxima no início
    }

    // Método chamado quando este objeto colide com outro objeto que possui um Collider2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto com o qual colidimos tem uma "tag" específica (você pode configurar tags nos objetos no Unity Editor)
        if (collision.gameObject.CompareTag("PlayerSword"))
        {
            // Reduz a vida do inimigo (você pode ajustar isso conforme necessário)
            TakeDamage(50); // Reduz 10 de vida quando um projétil colide

            // Aqui você pode adicionar qualquer lógica adicional que desejar quando um projétil colide com o inimigo
        }
    }

    // Método para reduzir a vida do inimigo
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduz a vida atual pelo valor do dano

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

        // Por exemplo, você pode destruir o objeto do inimigo quando ele morrer
        Destroy(gameObject);
    }
}
