using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeGameUi : MonoBehaviour
{
    public GameObject CharacterSelectPanel;

    public void SelectCharacter(string characterName)
    {
        PlayerPrefs.SetString("SelectedCharacter", characterName);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void turnOffPanel()
    {
        CharacterSelectPanel.SetActive(false);
    }
    public void turnOnPanel()
    {
        CharacterSelectPanel.SetActive(true);
    }
}
