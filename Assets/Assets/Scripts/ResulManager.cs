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
        // Ð?i cho ð?n khi ðo?n nh?c phát xong
        yield return new WaitForSeconds(theMusic.clip.length);

        yield return new WaitForSeconds(1f);//ð?i 3 giây sau khi nh?c xong
        // Ki?m tra máu ngý?i chõi
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

        // T?m d?ng game khi k?t thúc
        Time.timeScale = 0;
    }
}
