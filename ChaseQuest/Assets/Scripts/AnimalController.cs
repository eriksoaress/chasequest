using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{   
    public static AnimalController instance;
    public float moveSpeedAnimal = 3f;
    private Vector2 animalDirection;
    private Rigidbody2D animalRB;
    public DetectionController detectionArea;
    private SpriteRenderer spriteRenderer;

    private Knockback knockback;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        knockback = GetComponent<Knockback>();
    }
    void Start()
    {
        animalRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        animalDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        if (knockback.gettingKnockedBack)
        {
            return;
        }
        if (detectionArea.detectedObjs.Count > 0)
        {
        animalDirection = (detectionArea.detectedObjs[0].transform.position - transform.position).normalized;
        animalRB.MovePosition(animalRB.position + animalDirection * moveSpeedAnimal * Time.fixedDeltaTime);

        if (animalDirection.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }}
    }

}
