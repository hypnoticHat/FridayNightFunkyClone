using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider healthBar;
    public float minValue = -20f; 
    public float maxValue = 20f; 

    private float currentHealth = 0f;
    private UIFunction uiFunction;

    void Start()
    {
        uiFunction = GetComponentInParent<UIFunction>();

        healthBar.minValue = minValue;
        healthBar.maxValue = maxValue;
        healthBar.value = currentHealth;
    }

    public void UpdateHealth(bool isPlayer, int value)
    {
        // N�u l� player hit, gi?m m�u(v? player ph�a b�n ph?i n�n �?y thanh m�u ti?n v? tr�i l� gi� tr? �m)
        if (isPlayer)
        {
            currentHealth -= value;
        }
        // N?u l� enemy hit, t�ng m�u
        else
        {
            currentHealth += value;
        }
        // �?m b?o gi� tr? hi?n t?i n?m trong kho?ng min v� max
        currentHealth = Mathf.Clamp(currentHealth, minValue, maxValue);
        healthBar.value = currentHealth;

        //n?u m�u v�?t qu� ng��ng max th? enemy th?ng
        if (currentHealth >= maxValue)
        {
            uiFunction.Lose();
        }
    }

    // Ph��ng th?c �? l?y gi� tr? m�u hi?n t?i
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
