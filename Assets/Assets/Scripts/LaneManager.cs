using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    [Header("Lane Position")]
    public Transform laneUp;
    public Transform laneDown;
    public Transform laneLeft;
    public Transform laneRight;

    [Header("Player note Prefab")]
    public GameObject notePrefabUp;
    public GameObject notePrefabDown;
    public GameObject notePrefabLeft;
    public GameObject notePrefabRight;

    [Header("Enemy note Prefab")]
    public GameObject enemyNotePrefabUp;
    public GameObject enemyNotePrefabDown;
    public GameObject enemyNotePrefabLeft;
    public GameObject enemyNotePrefabRight;

    public Transform notesParent;

    public float spawnDelay = 0.5f; // Kho?ng th?i gian gi?a c�c l?n t?o note

    private List<string> noteLines; // L�u tr? c�c d?ng t? file

    void Start()
    {
        // �?c d? li?u t? file .txt trong Resources
        LoadNoteData();
    }

    void LoadNoteData()
    {
        noteLines = new List<string>();

        // S? d?ng Resources.Load �? t?i file t? Resources
        TextAsset txtFile = Resources.Load<TextAsset>("notes");
        if (txtFile != null)
        {
            string[] lines = txtFile.text.Split('\n'); // Chia t?ng d?ng t? n?i dung file

            foreach (string line in lines)
            {
                noteLines.Add(line.Trim()); // Th�m t?ng d?ng v�o danh s�ch v� lo?i b? kho?ng tr?ng
            }
        }
        else
        {
            Debug.LogError("File not found in Resources!");
        }
    }

    public void StartSpawningNotes()
    {
        StartCoroutine(SpawnNotes());
    }

    IEnumerator SpawnNotes()
    {
        foreach (string line in noteLines)
        {
            if (line.Length >= 4)
            {
                // T?o note cho t?ng l�n d?a tr�n k? t? trong d?ng
                if (line[0] == '1')
                {
                    Instantiate(notePrefabLeft, laneLeft.position, Quaternion.identity, notesParent);
                }
                else if (line[0] == '2')
                {
                    Instantiate(enemyNotePrefabLeft, laneLeft.position, Quaternion.identity, notesParent);
                }

                if (line[1] == '1')
                {
                    Instantiate(notePrefabUp, laneUp.position, Quaternion.identity, notesParent);
                }
                else if (line[1] == '2')
                {
                    Instantiate(enemyNotePrefabUp, laneUp.position, Quaternion.identity, notesParent);
                }

                if (line[2] == '1')
                {
                    Instantiate(notePrefabDown, laneDown.position, Quaternion.identity, notesParent);
                }
                else if (line[2] == '2')
                {
                    Instantiate(enemyNotePrefabDown, laneDown.position, Quaternion.identity, notesParent);
                }

                if (line[3] == '1')
                {
                    Instantiate(notePrefabRight, laneRight.position, Quaternion.identity, notesParent);
                }
                else if (line[3] == '2')
                {
                    Instantiate(enemyNotePrefabRight, laneRight.position, Quaternion.identity, notesParent);
                }
            }

            // Ch? m?t kho?ng th?i gian tr�?c khi t?o note ti?p theo
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
