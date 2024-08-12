using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Thành ph?n SpriteRenderer c?a nhân v?t
    public Sprite idleSprite; // Sprite m?c ð?nh (Idle)

    void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    public void ChangeToSpecificSprite(Sprite newSprite, float duration)
    {
        // Thay ð?i sprite c?a nhân v?t
        spriteRenderer.sprite = newSprite;

        // Sau m?t kho?ng th?i gian, tr? l?i sprite v? idle
        Invoke("ChangeToIdleSprite", duration);
    }

    private void ChangeToIdleSprite()
    {
        spriteRenderer.sprite = idleSprite;
    }
}
