using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //created a gamemanager to keep track of the players health
    //we can move player health to a player script I just figured we would want this script anyway for enemy spawns and wave generation etc.
    public static GameManager gameManager;

    private int scoreCounter = 0;

    private Text score;

    public int ScoreCounter {
        get {
            return scoreCounter;
        }
        set{
            scoreCounter = value;
        }
    }

    void Awake()
    {
        if(gameManager != null && gameManager != this) {
            Destroy(this);
        }
        else {
            gameManager = this;
        }
        scoreCounter = 0;
        score = gameObject.GetComponentInChildren<Text>();
    }

    void Update() {
        score.text = (scoreCounter * 10).ToString();
    }
}
