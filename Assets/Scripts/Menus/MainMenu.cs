using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{

    public GameObject exitBtn;
    public GameObject restartBtn;
   
    void Start()
    {

    }


    // Restart game when restartBtn or restartBtnBack onClick is activated.
    public void StartGame() {
        Debug.Log("StartGame");
        SceneManager.LoadScene(1);
    }
}