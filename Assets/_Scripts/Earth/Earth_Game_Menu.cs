using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Earth_Game_Menu : MonoBehaviour {


    public GameObject pauseMenu;
    public GameObject startMenu;
    public GameObject statisticMenu;
    public GameObject gameUI;
    // Use this for initialization
    private void Start()
    {
        //startMenu.SetActive(true);
       // pauseMenu.SetActive(false);
        statisticMenu.SetActive(false);
    }

    // Update is called once per frame
     void Update()
     {
         if (Input.GetKeyDown(KeyCode.Escape))
         {
            ContinueGame();
         }
     }

     public void PauseGame()
     {

         pauseMenu.SetActive(true);
         gameUI.SetActive(false);
         //Earth_Game.btnGame = 0;
     }
    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        gameUI.SetActive(true);
        //Earth_Game.btnGame = 1;
    }
    public void Quit()
    {
       // MainMenuC.connectionDone = true;
        SceneManager.LoadScene(0);
    }
    public void ShowStat()
    {
        statisticMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void HideStartMenu()
    {
        startMenu.SetActive(false);
    }
    public void HideStat()
    {
        statisticMenu.SetActive(false);
    }
}
