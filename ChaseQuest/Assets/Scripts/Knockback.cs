using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public bool gettingKnockedBack { get; private set; }

    [SerializeField] private float knockbackTime = 0.2f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void GetKnockedBack(Transform source, float force)
    {
        gettingKnockedBack = true;
        Vector2 difference = (transform.position - source.position).normalized * force*rb.mass;
        rb.AddForce(difference, ForceMode2D.Impulse);
        StartCoroutine(KnockbackTime());
    }

    private IEnumerator KnockbackTime()
    {
        yield return new WaitForSeconds(knockbackTime);
        rb.velocity = Vector2.zero; 
        gettingKnockedBack = false;
    }
}   

