using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //created a gamemanager to keep track of the players health
    //we can move player health to a player script I just figured we would want this script anyway for enemy spawns and wave generation etc.
    public static GameManager gameManager;

    void Awake()
    {
        if(gameManager != null && gameManager != this) {
            Destroy(this);
        }
        else {
            gameManager = this;
        }
    }
}
