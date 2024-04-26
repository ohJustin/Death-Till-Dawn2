using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    private GameObject player;
    private int scoreCounter = 0;
    private int killCounter = 0;
    // Can changed based on number of guns starting with
    private int totalWeapons = 3;
    // Current weapon that is selected
    private int currentWeaponIndex;
    private Sprite icon;

    private GameObject gunIcon;

    // Array to hold references to gun scripts
    private PlayerShoot[] gunScripts; 

    [SerializeField] private TextMeshProUGUI scoreCounterText;
    [SerializeField] private TextMeshProUGUI timeText;

    [SerializeField] private TextMeshProUGUI magazineSizeText;
    [SerializeField] private TextMeshProUGUI magazineCountText;

    [SerializeField] private Button qButton;
    [SerializeField] private Button eButton;
    public GameObject pauseWindow;

    public bool isPaused = false;
    //[SerializeField] private WeaponUI weaponUI;

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



    void Start()
    {
      //optionsWindow = GameObject.Find("OptionsWindow");
      pauseWindow.SetActive(false);
      isPaused = false;
    }

    void Awake()
    {
        //UpdateAmmo();
        if (gameManager != null && gameManager != this) {
            Destroy(this.gameObject);
        }
        else {
            gameManager = this;
        }
        scoreCounter = 0;

        gunIcon = GameObject.FindGameObjectWithTag("GUN");

        currentWeaponIndex = 0;

        // Initialize the array of gun scripts
        //gunScripts = new PlayerShoot[totalWeapons];
        player = GameObject.FindGameObjectWithTag("Player");

        //Debug.Log(player);

        gunScripts = new PlayerShoot[3];
        
        // Add references to the different gun scripts
        gunScripts[0] = player.GetComponent<PlayerShoot>();
        gunScripts[1] = player.GetComponent<MachineGun>();
        gunScripts[2] = player.GetComponent<ShotGun>();

        // for(int i = 0; i < 3; i++) {
        //     Debug.Log(gunScripts[i]);
        // }
        // for(int i = 0; i < 3; i++) {
        //     Debug.Log(gunScripts[i].icon);
        // }

        // Set the pistol as the current weapon initially
        //SwitchWeapon(0);

        StartTimer(); // Start the timer
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused == false){
                isPaused = true;
                Debug.Log("Escape key was pressed");
                pauseWindow.SetActive(true);
                Time.timeScale = 0f; // Paused Game.
            }else{
                isPaused = false;
                Debug.Log("Escape key was pressed");
                pauseWindow.SetActive(false);
                Time.timeScale = 1f; // Paused Game.
            }
        }

        if(isPaused == true) {
            return;
        }

        UpdateScoreUI();
        UpdateAmmo();
   
        // Check for input to switch weapons
        if (Input.GetKeyDown(KeyCode.E)) {
            SwitchToNextWeapon();
        }
        else if (Input.GetKeyDown(KeyCode.Q)) {
            SwitchToPreviousWeapon();
        }

        // Update button opacity
        UpdateButtonOpacity(KeyCode.E, eButton);
        UpdateButtonOpacity(KeyCode.Q, qButton);
    }

    private void UpdateButtonOpacity(KeyCode keyCode, Button button)
    {
        if (Input.GetKeyDown(keyCode))
        {
            // Key is pressed, change opacity to 1
            Color buttonColor = button.image.color;
            buttonColor.a = 1f;
            button.image.color = buttonColor;
        }
        else if (Input.GetKeyUp(keyCode))
        {
            // Key is released, change opacity back to 0.5 (or any other desired value)
            Color buttonColor = button.image.color;
            buttonColor.a = 0.5f;
            button.image.color = buttonColor;
        }
    }

    void SwitchToNextWeapon() {
        int temp_index = (currentWeaponIndex + 1) % totalWeapons;
        SwitchWeapon(temp_index);
    }

    void SwitchToPreviousWeapon() {
        int temp_index = (currentWeaponIndex - 1 + totalWeapons) % totalWeapons;
        SwitchWeapon(temp_index);
    }

    void SwitchWeapon(int index) {
        // Deactivate the current gun script
        if (gunScripts[currentWeaponIndex] != null) {
            gunScripts[currentWeaponIndex].enabled = false;
        }
        
        // Activate the new gun script
        currentWeaponIndex = index;
        gunIcon.GetComponent<Image>().sprite = gunScripts[currentWeaponIndex].icon;
        gunScripts[currentWeaponIndex].enabled = true;
        UpdateAmmo();

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

    private void UpdateAmmo() {
        if(currentWeaponIndex == 0) {
            magazineCountText.text = "∞";
            magazineSizeText.text = gunScripts[0].ammoInClip.ToString();
        }
        else {
            magazineCountText.text = gunScripts[currentWeaponIndex].ammoLeftTotal.ToString();
            magazineSizeText.text = gunScripts[currentWeaponIndex].ammoInClip.ToString();
        }
    }
}

