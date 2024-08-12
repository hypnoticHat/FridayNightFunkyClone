using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieSpriteChanger : MonoBehaviour
{
    public Sprite spriteToChange; // Sprite mà k? thù s? chuy?n ð?i sang khi note này ðý?c hit
    public Sprite idleSprite;     // Sprite idle mà k? thù s? tr? v? sau khi ð?i sprite
    public float spriteDuration = 0.2f; // Th?i gian hi?n th? sprite trý?c khi tr? v? idle

    private SpriteRenderer enemySpriteRenderer;

    void Start()
    {
        // T?m SpriteRenderer c?a k? thù
        enemySpriteRenderer = GameObject.FindWithTag("Enemy").GetComponent<SpriteRenderer>();

        if (enemySpriteRenderer == null)
        {
            Debug.LogError("Enemy's SpriteRenderer not found!");
            return;
        }
    }

    public void ChangeSprite()
    {

            // Thay ð?i sprite c?a k? thù
            enemySpriteRenderer.sprite = spriteToChange;
            // Khôi ph?c l?i sprite idle sau kho?ng th?i gian
            Invoke("ResetToIdleSprite", spriteDuration);

    }

    private void ResetToIdleSprite()
    {

            enemySpriteRenderer.sprite = idleSprite;
    }
}
