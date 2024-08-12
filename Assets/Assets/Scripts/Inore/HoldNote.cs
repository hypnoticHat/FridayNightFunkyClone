using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldNote : MonoBehaviour
{
    public KeyCode keyToPress; // Phím c?n nh?n ð? gi? n?t
    public float holdDuration; // Th?i gian c?n gi? phím
    private float holdTimeCounter; // Th?i gian gi? phím hi?n t?i
    private bool isHolding;
    public bool canBePressed; // Ki?m tra n?u n?t có th? ðý?c nh?n

    void Start()
    {
        holdTimeCounter = holdDuration; // Thi?t l?p th?i gian gi? ban ð?u
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress) && canBePressed)
        {
            isHolding = true;
        }

        if (Input.GetKey(keyToPress) && isHolding)
        {
            holdTimeCounter -= Time.deltaTime; // Gi?m th?i gian gi? d?a trên th?i gian th?c

            if (holdTimeCounter <= 0)
            {
                HandleNoteHit(); // N?u gi? ð? th?i gian th? g?i hàm x? l? hit
                isHolding = false;
            }
        }

        if (Input.GetKeyUp(keyToPress) && isHolding)
        {
            isHolding = false;
            HandleNoteMissed(); // N?u ngý?i chõi nh? phím gi?a ch?ng, g?i hàm x? l? miss
        }
    }

    private void HandleNoteHit()
    {
        gameObject.SetActive(false); // T?t n?t sau khi hit thành công
        GameManager.instance.PerfectHit(); // G?i hàm hit thành công t? GameManager
    }

    private void HandleNoteMissed()
    {
        gameObject.SetActive(false); // T?t n?t n?u miss
        GameManager.instance.noteMissed(); // G?i hàm miss t? GameManager
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
            if (!isHolding)
            {
                HandleNoteMissed(); // N?u n?t r?i kh?i vùng ho?t ð?ng mà chýa ðý?c gi?, tính là miss
            }
        }
    }
}
