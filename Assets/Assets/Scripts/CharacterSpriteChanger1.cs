using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteChanger1 : MonoBehaviour
{
    public Sprite idleSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite upSprite;
    public Sprite downSprite;

    public float spriteDuration = 0.2f; // Th?i gian hi?n th? sprite trý?c khi tr? v? idle

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // T?m SpriteRenderer c?a nhân v?t
        spriteRenderer = GetComponent<SpriteRenderer>();


        // Ð?t sprite ban ð?u là idleSprite n?u nó ðý?c thi?t l?p
        if (idleSprite != null)
        {
            spriteRenderer.sprite = idleSprite;
        }
    }

    public void ChangeSprite(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                spriteRenderer.sprite = leftSprite;
                break;
            case Direction.Right:
                spriteRenderer.sprite = rightSprite;
                break;
            case Direction.Up:
                spriteRenderer.sprite = upSprite;
                break;
            case Direction.Down:
                spriteRenderer.sprite = downSprite;
                break;
        }

        // Khôi ph?c l?i sprite idle sau m?t kho?ng th?i gian
        Invoke("ResetToIdle", spriteDuration);
    }

    private void ResetToIdle()
    {
        if (idleSprite != null)
        {
            spriteRenderer.sprite = idleSprite;
        }
    }
}

public enum Direction
{
    Left,
    Right,
    Up,
    Down
}
