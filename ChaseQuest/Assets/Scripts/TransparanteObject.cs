using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparateObject : MonoBehaviour
{


    [Range(0, 1)]
    [SerializeField] private float transparencyValue = 0.7f;
    [SerializeField] private float transparencyFadeTime = 0.4f;
    private SpriteRenderer spriteRenderer;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            StartCoroutine(fadeTransparency(spriteRenderer, transparencyFadeTime, spriteRenderer.color.a, transparencyValue));
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            StartCoroutine(fadeTransparency(spriteRenderer, transparencyFadeTime, spriteRenderer.color.a, 1));
        }
    }
    

    private IEnumerator fadeTransparency(SpriteRenderer spriteTransparency, float fadeTime, float startValue, float targetTransparency)
    {
        float timeElapsed = 0;
        while (timeElapsed < fadeTime)
        {
            timeElapsed += Time.deltaTime;
            float newaAlpha = Mathf.Lerp(startValue, targetTransparency, timeElapsed / fadeTime);
            spriteTransparency.color = new Color(spriteTransparency.color.r, spriteTransparency.color.g, spriteTransparency.color.b, newaAlpha);
            yield return null;
        }
    }
}


