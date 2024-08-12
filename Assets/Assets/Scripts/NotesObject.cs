using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public GameObject hitEffect, goodEffect, PerfectEffect;

    public Direction noteDirection;
    public CharacterSpriteChanger1 characterSpriteChanger;
    public HealthBarController healthBarController;
    void Start()
    {
        
        characterSpriteChanger = GameObject.FindWithTag("Player").GetComponent<CharacterSpriteChanger1>();
      
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress) && canBePressed)
        {
            characterSpriteChanger.ChangeSprite(noteDirection);
            gameObject.SetActive(false);
            HandleNoteHit();
            //Destroy(gameObject);
        }
    }

    private void HandleNoteHit()
    {

        // X? l? các hi?u ?ng khác (tùy ch?n)
        if (Mathf.Abs(transform.position.y) > 0.25f)
        {
            GameManager.instance.NormalHit();
            Instantiate(hitEffect, hitEffect.transform.position, hitEffect.transform.rotation);
        }
        else if (Mathf.Abs(transform.position.y) > 0.1f)
        {
            GameManager.instance.goodHit();
            Instantiate(goodEffect, goodEffect.transform.position, goodEffect.transform.rotation);
        }
        else
        {
            GameManager.instance.PerfectHit();
            Instantiate(PerfectEffect, PerfectEffect.transform.position, PerfectEffect.transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = false;
            GameManager.instance.noteMissed();
            
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
