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

    [SerializeField] private TextMeshProUGUI scoreCounterText;
    [SerializeField] private TextMeshProUGUI timeText;

    private float timer = 0f; // Timer variable to hold the elapsed time

    public int ScoreCounter {
        get {
            return scoreCounter;
        }
        set {
            scoreCounter = value;
            UpdateScoreUI();
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
        // scoreCounterText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        //scoreCounterText = gameObject.GetComponentInChildren<TextMeshProUGUI>(); 
        //timeText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        StartTimer(); // Start the timer coroutine
    }

    void Update() {
        UpdateScoreUI();
    }

    private void UpdateScoreUI() {
        // Update Kill Counter UI
        scoreCounterText.text = "Score: " + (scoreCounter * 10).ToString();
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

