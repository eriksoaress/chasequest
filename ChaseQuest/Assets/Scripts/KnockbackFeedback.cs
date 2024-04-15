using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockbackFeedback : MonoBehaviour
{   
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float strength = 16, delay = 0.15f;
    
    public UnityEvent OnBegin,OnDone;

    public void PlayFeedback(GameObject target){
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position-target.transform.position).normalized;
        rb.AddForce(direction*strength,ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    private IEnumerator Reset(){
        yield return new WaitForSeconds(delay);
        rb.velocity = Vector2.zero;
        OnDone?.Invoke();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
