using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource theMusic;//Audio Source Cho ph?n nh?c (tách ð?c l?p ð? t?o setting v? sau
    public AudioSource audioPlayer; // AudioSource duy nh?t ð? phát các âm thanh ð?m ngý?c và "GO!"
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
        // B?t h?nh ?nh ð?m ngý?c
        countdownImage.gameObject.SetActive(true);

        for (int i = 0; i < countdownSprites.Length - 1; i++) // Tr? 1 ð? không bao g?m GO!
        {
            countdownImage.sprite = countdownSprites[i];
            countdownImage.rectTransform.localScale = Vector3.one * 2f; // B?t ð?u v?i kích thý?c l?n hõn

            audioPlayer.clip = countdownClips[i]; // Gán âm thanh týõng ?ng t? m?ng
            audioPlayer.Play(); // Phát âm thanh ð?m ngý?c

            // Animate scale t? l?n ð?n nh? trong 1 giây
            for (float t = 0; t < 1f; t += Time.deltaTime)
            {
                countdownImage.rectTransform.localScale = Vector3.Lerp(Vector3.one * 2f, Vector3.one, t);
                yield return null;
            }

            yield return new WaitForSeconds(1f); // Ch? 1 giây trý?c khi chuy?n sang s? ti?p theo
        }

        // Hi?n th? "GO!" và b?t ð?u tr? chõi
        countdownImage.sprite = countdownSprites[countdownSprites.Length - 1];
        audioPlayer.clip = goAudioClip; // Gán âm thanh "GO!"
        audioPlayer.Play(); // Phát âm thanh khi b?t ð?u tr? chõi
        countdownImage.rectTransform.localScale = Vector3.one * 2f; // B?t ð?u v?i kích thý?c l?n hõn

        // Animate scale t? l?n ð?n nh? cho "GO!"
        for (float t = 0; t < 1f; t += Time.deltaTime)
        {
            countdownImage.rectTransform.localScale = Vector3.Lerp(Vector3.one * 2f, Vector3.one, t);
            yield return null;
        }

        yield return new WaitForSeconds(1f); // Ch? 1 giây ð? gi? "GO!" trên màn h?nh

        countdownImage.gameObject.SetActive(false); // ?n h?nh ?nh ð?m ngý?c

        // B?t ð?u tr? chõi
        startPlaying = true;
        theBS.hasStarted = true;
        theMusic.Play();

        PauseBtn.SetActive(true);
        laneManager.StartSpawningNotes(); // B?t ð?u t?o n?t nh?c
        musicManager.StartMusicCheck();   // B?t ð?u ki?m tra khi nh?c k?t thúc
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

        // Thay ð?i sprite khi b?m trúng n?t
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
        //c?p nh?p m?t máu n?u trý?t
        healthManager.UpdateHealth(false, 2);

        currentMultiplier = 1;
        multiplierTracker = 0;
        missedNotesCount++;
        MissedText.text = "Missed: " + missedNotesCount;
    }
}
