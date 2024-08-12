using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHomeMove : MonoBehaviour
{
    public float speed = 2.0f; // T?c �? di chuy?n c?a camera
    public float acceleration = 0.1f; // �? t�ng t?c d?n d?n
    public float maxOffset = 5.0f; // �? l?ch t?i �a t? v? tr� ban �?u theo chi?u X

    private float currentSpeed;
    private Vector3 startPosition;
    private bool movingRight = true; // �ang di chuy?n sang ph?i hay tr�i

    void Start()
    {
        startPosition = transform.position;
        currentSpeed = speed;
    }

    void Update()
    {
        // T�nh to�n v? tr� m?i theo chi?u X
        float newX = transform.position.x + (currentSpeed * Time.deltaTime * (movingRight ? 1 : -1));

        // Ki?m tra xem camera c� ch?m �?n r?a ph?i ho?c tr�i kh�ng
        if (newX >= startPosition.x + maxOffset)
        {
            newX = startPosition.x + maxOffset;
            movingRight = false; // �?i h�?ng khi ch?m �?n r?a ph?i
        }
        else if (newX <= startPosition.x - maxOffset)
        {
            newX = startPosition.x - maxOffset;
            movingRight = true; // �?i h�?ng khi ch?m �?n r?a tr�i
        }

        // Di chuy?n camera �?n v? tr� m?i
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        // T�ng d?n t?c �? �?n khi �?t gi� tr? max, sau �� gi?m d?n khi �?o h�?ng
        if (movingRight)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= acceleration * Time.deltaTime;
        }

        // Gi? t?c �? trong gi?i h?n nh?t �?nh
        currentSpeed = Mathf.Clamp(currentSpeed, speed, speed * 2);
    }
}
