using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHomeMove : MonoBehaviour
{
    public float speed = 2.0f; // T?c ð? di chuy?n c?a camera
    public float acceleration = 0.1f; // Ð? tãng t?c d?n d?n
    public float maxOffset = 5.0f; // Ð? l?ch t?i ða t? v? trí ban ð?u theo chi?u X

    private float currentSpeed;
    private Vector3 startPosition;
    private bool movingRight = true; // Ðang di chuy?n sang ph?i hay trái

    void Start()
    {
        startPosition = transform.position;
        currentSpeed = speed;
    }

    void Update()
    {
        // Tính toán v? trí m?i theo chi?u X
        float newX = transform.position.x + (currentSpeed * Time.deltaTime * (movingRight ? 1 : -1));

        // Ki?m tra xem camera có ch?m ð?n r?a ph?i ho?c trái không
        if (newX >= startPosition.x + maxOffset)
        {
            newX = startPosition.x + maxOffset;
            movingRight = false; // Ð?i hý?ng khi ch?m ð?n r?a ph?i
        }
        else if (newX <= startPosition.x - maxOffset)
        {
            newX = startPosition.x - maxOffset;
            movingRight = true; // Ð?i hý?ng khi ch?m ð?n r?a trái
        }

        // Di chuy?n camera ð?n v? trí m?i
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        // Tãng d?n t?c ð? ð?n khi ð?t giá tr? max, sau ðó gi?m d?n khi ð?o hý?ng
        if (movingRight)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= acceleration * Time.deltaTime;
        }

        // Gi? t?c ð? trong gi?i h?n nh?t ð?nh
        currentSpeed = Mathf.Clamp(currentSpeed, speed, speed * 2);
    }
}
