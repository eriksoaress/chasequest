using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{   

    // pegar o audio source do player para tocar o som de ataque
    public SoundEffectsPlayer soundPlayer;

    public GameObject attackArea = default;
    private bool isAttacking = false;
    public float attackTime = 0.25f;
    private float timer = 0f;

    public float attackCooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isAttacking && attackCooldown <= 0f){
            Attack();
        }

        if(attackCooldown > 0f){
            attackCooldown -= Time.deltaTime;
        }

        if(isAttacking){
            timer += Time.deltaTime;
            if(timer >= attackTime){
                isAttacking = false;
                attackArea.SetActive(false);
                attackCooldown = 1f;
                timer = 0f;
            }
        }
    }

    private void Attack(){
        isAttacking = true;
        attackArea.SetActive(true);
        soundPlayer.PlayAttackSFX();

    }

    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Enemy") && isAttacking){
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(25);
        }
    }
}
