using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Importe a biblioteca UnityEngine.UI para acessar os componentes UI

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider; // Referência para o Slider de vida

    private bool damaged;
    private float damageCooldown = 0.25f;
    private float cooldownTimer;

    private Knockback knockback;
    public SoundEffectsPlayer soundPlayer;

    private void Awake()
    {
        knockback = GetComponent<Knockback>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        cooldownTimer = damageCooldown;
        UpdateHealthUI(); // Atualize o Slider de vida quando o jogo começar
    }

    void Update()
    {
        if (damaged)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                damaged = false;
                cooldownTimer = damageCooldown;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !damaged)
        {
            TakeDamage(25);
            damaged = true;
            soundPlayer.PlayDamageSFX();

        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        knockback.GetKnockedBack(AnimalController.instance.transform, 10f);
        StartCoroutine(FlashRed());

        if (currentHealth <= 0)
        {
            Die();
        }

        UpdateHealthUI(); // Atualize o Slider de vida sempre que o jogador sofrer dano
    }

    private IEnumerator FlashRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void Die()
    {
        Debug.Log("Player died");
        gameObject.SetActive(false);
    }

    private void UpdateHealthUI()
    {
        if (healthSlider != null) // Verifique se a referência do Slider de vida não é nula
        {
            healthSlider.value = (float)currentHealth / maxHealth; // Atualize o valor do Slider
        }
    }
}
