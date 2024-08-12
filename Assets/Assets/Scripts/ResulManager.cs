using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResulManager : MonoBehaviour
{
    public AudioSource theMusic;  
    public GameObject winPanel; 
    public GameObject losePanel; 
    public HealthBarController healthBar;

    public void StartMusicCheck()
    {
        StartCoroutine(CheckMusicEnd());
    }

    IEnumerator CheckMusicEnd()
    {
        // �?i cho �?n khi �o?n nh?c ph�t xong
        yield return new WaitForSeconds(theMusic.clip.length);

        yield return new WaitForSeconds(1f);//�?i 3 gi�y sau khi nh?c xong
        // Ki?m tra m�u ng�?i ch�i
        if (healthBar.GetCurrentHealth() <= healthBar.maxValue)
        {
            // Hi?n th? panel chi?n th?ng
            winPanel.SetActive(true);
        }
        else
        {
            // Hi?n th? panel thua cu?c
            losePanel.SetActive(true);
        }

        // T?m d?ng game khi k?t th�c
        Time.timeScale = 0;
    }
}
