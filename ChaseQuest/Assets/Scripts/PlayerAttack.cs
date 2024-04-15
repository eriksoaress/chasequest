using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{   
    public GameObject attackArea = default;
    private bool isAttacking = false;
    private float attackTime = 0.25f;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isAttacking){
            Attack();
        }

        if(isAttacking){
            timer += Time.deltaTime;
            if(timer >= attackTime){
                isAttacking = false;
                attackArea.SetActive(false);
                timer = 0f;
            }
        }
    }

    private void Attack(){
        isAttacking = true;
        attackArea.SetActive(true);
    }
}
