using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    private int scoreCounter = 0;
    private int killCounter = 0;

    private Text score;

    [SerializeField] private TextMeshProUGUI killCounterText;
    [SerializeField] private TextMeshProUGUI timeText;

    private float timer = 0f; // Timer variable to hold the elapsed time

    public int ScoreCounter {
        get {
            return scoreCounter;
        }
        set {
            scoreCounter = value;
        }
    }

    public int KillCounter {
        get {
            return killCounter;
        }
        set {
            killCounter = value;
            UpdateKillUI();
        }
    }

    void Awake()
    {
        if (gameManager != null && gameManager != this) {
            Destroy(this.gameObject);
        }
        else {
            gameManager = this;
        }
        scoreCounter = 0;
        score = gameObject.GetComponentInChildren<Text>();
        killCounterText = GetComponentInChildren<TextMeshProUGUI>(); // Assuming the TextMeshPro component is a child of GameManager
        timeText = GetComponentInChildren<TextMeshProUGUI>(); // Assuming the TextMeshPro component is a child of GameManager
        StartTimer(); // Start the timer coroutine
    }

    void Update() {
        score.text = (scoreCounter * 10).ToString();
    }

    private void UpdateKillUI() {
        // Update Kill Counter UI
        killCounterText.text = "Kills: " + killCounter.ToString();
    }

    // Method to increment the kill counter
    public void IncrementKill()
    {
        killCounter++;
    }

    // Coroutine to update the timer
    private IEnumerator UpdateTimer()
    {
        while (true)
        {
            timer += Time.deltaTime; // Increment the timer by the time between frames
            UpdateTimerUI(); // Update the timer UI
            yield return null; // Wait for the next frame
        }
    }

    // Method to start the timer coroutine
    private void StartTimer()
    {
        StartCoroutine(UpdateTimer());
    }

    // Method to format and update the timer UI
    private void UpdateTimerUI()
    {
        int hours = Mathf.FloorToInt(timer / 3600);
        int minutes = Mathf.FloorToInt((timer % 3600) / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}

