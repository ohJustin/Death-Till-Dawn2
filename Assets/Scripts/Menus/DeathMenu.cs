using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class DeathMenu : MonoBehaviour
{

    public GameObject exitBtn;
    public GameObject restartBtn;
   
    void Start()
    {

    }


    // Restart game when restartBtn or restartBtnBack onClick is activated.
    public void RestartGame() {
        Debug.Log("RestartGame");
        // SceneManager.LoadScene(1);
    }


     // Return to menu when quitBtn or quitBtnBack onClick is activated.
    public void QuitToMenu() {
        Debug.Log("QuitToMenu");
        SceneManager.LoadScene(0);
    }
}
