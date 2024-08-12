using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Th�nh ph?n SpriteRenderer c?a nh�n v?t
    public Sprite idleSprite; // Sprite m?c �?nh (Idle)

    void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    public void ChangeToSpecificSprite(Sprite newSprite, float duration)
    {
        // Thay �?i sprite c?a nh�n v?t
        spriteRenderer.sprite = newSprite;

        // Sau m?t kho?ng th?i gian, tr? l?i sprite v? idle
        Invoke("ChangeToIdleSprite", duration);
    }

    private void ChangeToIdleSprite()
    {
        spriteRenderer.sprite = idleSprite;
    }
}
