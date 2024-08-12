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
        // Nêu là player hit, gi?m máu(v? player phía bên ph?i nên ð?y thanh máu ti?n v? trái là giá tr? âm)
        if (isPlayer)
        {
            currentHealth -= value;
        }
        // N?u là enemy hit, tãng máu
        else
        {
            currentHealth += value;
        }
        // Ð?m b?o giá tr? hi?n t?i n?m trong kho?ng min và max
        currentHealth = Mathf.Clamp(currentHealth, minValue, maxValue);
        healthBar.value = currentHealth;

        //n?u máu vý?t quá ngýõng max th? enemy th?ng
        if (currentHealth >= maxValue)
        {
            uiFunction.Lose();
        }
    }

    // Phýõng th?c ð? l?y giá tr? máu hi?n t?i
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
