using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldNote : MonoBehaviour
{
    public KeyCode keyToPress; // Ph�m c?n nh?n �? gi? n?t
    public float holdDuration; // Th?i gian c?n gi? ph�m
    private float holdTimeCounter; // Th?i gian gi? ph�m hi?n t?i
    private bool isHolding;
    public bool canBePressed; // Ki?m tra n?u n?t c� th? ��?c nh?n

    void Start()
    {
        holdTimeCounter = holdDuration; // Thi?t l?p th?i gian gi? ban �?u
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress) && canBePressed)
        {
            isHolding = true;
        }

        if (Input.GetKey(keyToPress) && isHolding)
        {
            holdTimeCounter -= Time.deltaTime; // Gi?m th?i gian gi? d?a tr�n th?i gian th?c

            if (holdTimeCounter <= 0)
            {
                HandleNoteHit(); // N?u gi? �? th?i gian th? g?i h�m x? l? hit
                isHolding = false;
            }
        }

        if (Input.GetKeyUp(keyToPress) && isHolding)
        {
            isHolding = false;
            HandleNoteMissed(); // N?u ng�?i ch�i nh? ph�m gi?a ch?ng, g?i h�m x? l? miss
        }
    }

    private void HandleNoteHit()
    {
        gameObject.SetActive(false); // T?t n?t sau khi hit th�nh c�ng
        GameManager.instance.PerfectHit(); // G?i h�m hit th�nh c�ng t? GameManager
    }

    private void HandleNoteMissed()
    {
        gameObject.SetActive(false); // T?t n?t n?u miss
        GameManager.instance.noteMissed(); // G?i h�m miss t? GameManager
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
                HandleNoteMissed(); // N?u n?t r?i kh?i v�ng ho?t �?ng m� ch�a ��?c gi?, t�nh l� miss
            }
        }
    }
}
