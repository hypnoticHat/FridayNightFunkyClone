using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpriteChanger : MonoBehaviour
{
    public Sprite spriteToChange; // Sprite mà nhân v?t s? chuy?n ð?i sang khi nút này ðý?c nh?n
    public float spriteDuration = 0.2f; // Th?i gian hi?n th? sprite trý?c khi tr? v? idle

    private CharacterSpriteChanger characterSpriteChanger;

    void Start()
    {
        // T?m ð?i tý?ng nhân v?t và l?y tham chi?u ð?n script CharacterSpriteChanger c?a nó
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
            // Thay ð?i sprite c?a nhân v?t khi có hit thành công
            characterSpriteChanger.ChangeToSpecificSprite(spriteToChange, spriteDuration);
        }
    }
}
