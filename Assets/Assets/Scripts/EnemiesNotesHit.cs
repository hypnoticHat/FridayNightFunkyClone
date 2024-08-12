using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesNotesHit : MonoBehaviour
{
    public GameObject hitEffect, goodEffect, PerfectEffect;
    //public EnemieSpriteChanger noteSpriteChanger;
    public Direction noteDirection; // Hý?ng c?a note này (left, right, up, down)
    public CharacterSpriteChanger1 characterSpriteChanger;
    public HealthBarController healthManager;

    private void Start()
    {
        characterSpriteChanger = GameObject.FindWithTag("Enemy").GetComponent<CharacterSpriteChanger1>();
        healthManager = GameObject.FindObjectOfType<HealthBarController>();
    }

    private void EnemieHit()
    {
        // Random m?t s? ð? quy?t ð?nh lo?i hit
        float hitRoll = Random.Range(0f, 1f);
        //noteSpriteChanger.ChangeSprite();
        characterSpriteChanger.ChangeSprite(noteDirection);
        if (hitRoll <= 0.2f)
        {
            PerfectHit();
        }
        else if (hitRoll <= 0.5f)
        {
            GoodHit();
        }
        else
        {
            BadHit();
        }

        // Sau khi x? l? hit, h?y ð?i tý?ng note
        Destroy(gameObject);
    }

    private void PerfectHit()
    {
        Instantiate(hitEffect, hitEffect.transform.position, hitEffect.transform.rotation);
        healthManager.UpdateHealth(false, 1);
    }

    private void GoodHit()
    {
        Instantiate(goodEffect, goodEffect.transform.position, goodEffect.transform.rotation);
        healthManager.UpdateHealth(false, 1);
    }

    private void BadHit()
    {
        Instantiate(PerfectEffect, PerfectEffect.transform.position, PerfectEffect.transform.rotation);
        healthManager.UpdateHealth(false, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemieHit();
    }
}
