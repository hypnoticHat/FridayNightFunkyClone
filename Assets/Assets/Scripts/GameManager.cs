using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource theMusic;//Audio Source Cho ph?n nh?c (t�ch �?c l?p �? t?o setting v? sau
    public AudioSource audioPlayer; // AudioSource duy nh?t �? ph�t c�c �m thanh �?m ng�?c v� "GO!"
    public AudioClip goAudioClip;
    public AudioClip[] countdownClips; 


    [Header("Varible")]
    public int currentScore;
    public int scorePerNote = 100;
    public int missedNotesCount;

    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public TMP_Text scoreText;
    public TMP_Text MissedText;

    public Image countdownImage;
    public Sprite[] countdownSprites;
    public GameObject PauseBtn;
    public bool canPress;
    public GameObject startPanel;

    [Header("Script")]
    public bool startPlaying;
    public BeatsScroller theBS;
    public static GameManager instance;
    private NoteSpriteChanger noteSpriteChanger;
    public HealthBarController healthManager;
    public LaneManager laneManager;
    public ResulManager musicManager;

    // Start is called before the first frame update
    void Start()
    {
        canPress = true;
        healthManager = GameObject.FindObjectOfType<HealthBarController>();
        instance = this;

        scoreText.text = "Score: 0";

        currentMultiplier = 1;
        missedNotesCount = 0;

        // Find Notesprite changer in screen
        noteSpriteChanger = FindObjectOfType<NoteSpriteChanger>();
        if (noteSpriteChanger == null)
        {
            Debug.LogError("NoteSpriteChanger not found in the scene!");
        }

        countdownImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying && canPress)
        {
            if (Input.anyKeyDown)
            {
                startPanel.SetActive(false);
                canPress = false;
                StartCoroutine(StartCountdown());
            }
        }
    }

    IEnumerator StartCountdown()
    {
        // B?t h?nh ?nh �?m ng�?c
        countdownImage.gameObject.SetActive(true);

        for (int i = 0; i < countdownSprites.Length - 1; i++) // Tr? 1 �? kh�ng bao g?m GO!
        {
            countdownImage.sprite = countdownSprites[i];
            countdownImage.rectTransform.localScale = Vector3.one * 2f; // B?t �?u v?i k�ch th�?c l?n h�n

            audioPlayer.clip = countdownClips[i]; // G�n �m thanh t��ng ?ng t? m?ng
            audioPlayer.Play(); // Ph�t �m thanh �?m ng�?c

            // Animate scale t? l?n �?n nh? trong 1 gi�y
            for (float t = 0; t < 1f; t += Time.deltaTime)
            {
                countdownImage.rectTransform.localScale = Vector3.Lerp(Vector3.one * 2f, Vector3.one, t);
                yield return null;
            }

            yield return new WaitForSeconds(1f); // Ch? 1 gi�y tr�?c khi chuy?n sang s? ti?p theo
        }

        // Hi?n th? "GO!" v� b?t �?u tr? ch�i
        countdownImage.sprite = countdownSprites[countdownSprites.Length - 1];
        audioPlayer.clip = goAudioClip; // G�n �m thanh "GO!"
        audioPlayer.Play(); // Ph�t �m thanh khi b?t �?u tr? ch�i
        countdownImage.rectTransform.localScale = Vector3.one * 2f; // B?t �?u v?i k�ch th�?c l?n h�n

        // Animate scale t? l?n �?n nh? cho "GO!"
        for (float t = 0; t < 1f; t += Time.deltaTime)
        {
            countdownImage.rectTransform.localScale = Vector3.Lerp(Vector3.one * 2f, Vector3.one, t);
            yield return null;
        }

        yield return new WaitForSeconds(1f); // Ch? 1 gi�y �? gi? "GO!" tr�n m�n h?nh

        countdownImage.gameObject.SetActive(false); // ?n h?nh ?nh �?m ng�?c

        // B?t �?u tr? ch�i
        startPlaying = true;
        theBS.hasStarted = true;
        theMusic.Play();

        PauseBtn.SetActive(true);
        laneManager.StartSpawningNotes(); // B?t �?u t?o n?t nh?c
        musicManager.StartMusicCheck();   // B?t �?u ki?m tra khi nh?c k?t th�c
    }

    public void noteHit()
    {
        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        scoreText.text = "Score: " + currentScore;

        // Thay �?i sprite khi b?m tr�ng n?t
        noteSpriteChanger?.TriggerSpriteChange();
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        noteHit();
        healthManager.UpdateHealth(true, 1);
    }

    public void goodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        noteHit();
        healthManager.UpdateHealth(true, 2);
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        noteHit();
        healthManager.UpdateHealth(true, 3);
    }

    public void noteMissed()
    {
        //c?p nh?p m?t m�u n?u tr�?t
        healthManager.UpdateHealth(false, 2);

        currentMultiplier = 1;
        multiplierTracker = 0;
        missedNotesCount++;
        MissedText.text = "Missed: " + missedNotesCount;
    }
}
