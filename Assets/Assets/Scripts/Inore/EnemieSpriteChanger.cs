using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieSpriteChanger : MonoBehaviour
{
    public Sprite spriteToChange; // Sprite m� k? th� s? chuy?n �?i sang khi note n�y ��?c hit
    public Sprite idleSprite;     // Sprite idle m� k? th� s? tr? v? sau khi �?i sprite
    public float spriteDuration = 0.2f; // Th?i gian hi?n th? sprite tr�?c khi tr? v? idle

    private SpriteRenderer enemySpriteRenderer;

    void Start()
    {
        // T?m SpriteRenderer c?a k? th�
        enemySpriteRenderer = GameObject.FindWithTag("Enemy").GetComponent<SpriteRenderer>();

        if (enemySpriteRenderer == null)
        {
            Debug.LogError("Enemy's SpriteRenderer not found!");
            return;
        }
    }

    public void ChangeSprite()
    {

            // Thay �?i sprite c?a k? th�
            enemySpriteRenderer.sprite = spriteToChange;
            // Kh�i ph?c l?i sprite idle sau kho?ng th?i gian
            Invoke("ResetToIdleSprite", spriteDuration);

    }

    private void ResetToIdleSprite()
    {

            enemySpriteRenderer.sprite = idleSprite;
    }
}
