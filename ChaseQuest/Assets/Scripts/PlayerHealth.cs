using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private bool damaged;

    private float damageCooldown = 0.25f;
    private float cooldownTimer;

    private Knockback knockback;
    // Start is called before the first frame update

    private void Awake(){
        knockback = GetComponent<Knockback>();
    }
    void Start()
    {
        currentHealth = maxHealth;
        cooldownTimer = damageCooldown;
    }

    // Update is called once per frame
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

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Enemy") && !damaged)
    //     {
    //         TakeDamage(25);
    //         damaged = true;
    //     }
    // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !damaged)
        {
            TakeDamage(25);
            damaged = true;
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // knockback.GetKnockedBack(PlayerController.instance.transform, 10f);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died");
        gameObject.SetActive(false);
    }
}
