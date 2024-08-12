using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteWobble : MonoBehaviour
{
    public float wobbleSpeed = 1.0f;
    public float wobbleAmount = 5.0f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
    }

    void Update()
    {
        float wobble = Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmount;
        transform.localPosition = startPosition + new Vector3(wobble, 0, 0);
    }
}
