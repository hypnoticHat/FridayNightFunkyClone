using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunction : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject LosePanel;
    public AudioSource Song; // Tham chi?u ð?n AudioSource ðang phát nh?c

    void Start()
    {
        if (Song == null)
        {
            // T? ð?ng t?m ki?m AudioSource n?u chýa ðý?c gán
            Song = FindObjectOfType<AudioSource>();
        }
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        Song.Pause();
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        Song.UnPause();
    }

    public void Lose()
    {
        LosePanel.SetActive(true);
        Time.timeScale = 0;
        Song.Pause();
    }

    // Function to reload the current scene (Try Again)
    public void TryAgain()
    {
        Time.timeScale = 1; // Ensure the game is not paused
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }

    // Function to go back to the home screen
    public void Home()
    {
        Time.timeScale = 1; // Ensure the game is not paused
        SceneManager.LoadScene(0);
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
