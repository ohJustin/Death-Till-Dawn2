using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class MainMenu : MonoBehaviour
{
   public GameObject optionsWindow;
  public GameObject aboutWindow;

    // For our other buttons that involve a prompt window, i'll be using unity's 'Button'.

    public TextMeshProUGUI messageText;
   
    void Start()
    {
      //optionsWindow = GameObject.Find("OptionsWindow");
      optionsWindow.SetActive(false);
      aboutWindow.SetActive(false);
    }

    public void ControlsClicked(){
           Debug.Log("Options selected.");
           optionsWindow.SetActive(true);
    }
    // Restart game when restartBtn or restartBtnBack onClick is activated.
    public void StartGame() {
        Debug.Log("StartGame");
        SceneManager.LoadScene(1);
    }

    public void DoneClicked(){
        optionsWindow.SetActive(false);
        aboutWindow.SetActive(false);
        Debug.Log("Done selected.");
    }
   
   
    public void AboutClicked(){
        aboutWindow.SetActive(true);
        Debug.Log("About selected.");
    }

    public void QuitClicked(){
        Application.Quit();
    }

   


}