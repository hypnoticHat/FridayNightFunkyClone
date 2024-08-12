using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpriteChanger : MonoBehaviour
{
    public Sprite spriteToChange; // Sprite m� nh�n v?t s? chuy?n �?i sang khi n�t n�y ��?c nh?n
    public float spriteDuration = 0.2f; // Th?i gian hi?n th? sprite tr�?c khi tr? v? idle

    private CharacterSpriteChanger characterSpriteChanger;

    void Start()
    {
        // T?m �?i t�?ng nh�n v?t v� l?y tham chi?u �?n script CharacterSpriteChanger c?a n�
        characterSpriteChanger = FindObjectOfType<CharacterSpriteChanger>();

        if (characterSpriteChanger == null)
        {
            Debug.LogError("CharacterSpriteChanger not found in the scene!");
        }
    }

    public void TriggerSpriteChange()
    {
        if (characterSpriteChanger != null)
        {
            // Thay �?i sprite c?a nh�n v?t khi c� hit th�nh c�ng
            characterSpriteChanger.ChangeToSpecificSprite(spriteToChange, spriteDuration);
        }
    }
}
