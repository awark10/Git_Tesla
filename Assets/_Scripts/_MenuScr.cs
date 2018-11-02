using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _MenuScr : MonoBehaviour
{
    public GameObject paiseMenu;
    public GameObject gameUI;
   // public GameObject startMenu;
   // public GameObject connectLoader;
    public GameObject statMenu;
    // public GameObject howMenu;
   // public Button connect;
    //public GameObject reconnect;
   // public GameObject backGrnd;

    

    private void Start()
    {
     
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
       // Time.timeScale = 0;
      //  backGrnd.SetActive(true);
        paiseMenu.SetActive(true);
        _StatScript.btnGame = 0;
       // gameUI.SetActive(false);
    }
    public void ContinueGame()
    {
      //  Time.timeScale = 1;
       // backGrnd.SetActive(false);
        paiseMenu.SetActive(false);
        gameUI.SetActive(true);
        _StatScript.btnGame = 1;
    }
    /*
    public void StartGame()
    {
        Time.timeScale = 1;

        startMenu.SetActive(false);

    }
    */

    public void Quit()
    {
        MainMenuC.connectionDone = true;
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {

        UnityThinkGear.Close();
       // connectLoader.SetActive(true);
        UnityThinkGear.StartStream();
    }

    public void RestartGame()
    {
      //  backGrnd.SetActive(false);
        paiseMenu.SetActive(false);
        gameUI.SetActive(true);
     //   Time.timeScale = 1;
        _StatScript.tmpStat = 1;
    }

    public void Connect()
    {
        _StatScript.btnGame = 1;
      //  connectLoader.SetActive(true);
       // connect.interactable = false;
       // try
       // {

            UnityThinkGear.StartStream();

       // }
        //catch (System.Exception e) { }
       
        //backGrnd.SetActive(false);
    }

    public void DisConn()
    {

        UnityThinkGear.Close();

    }

    public void StopCon()
    {
        //reconnect.SetActive(false);
       // connectLoader.SetActive(false);
      //  connect.interactable = true;
        UnityThinkGear.StopStream();

    }

    public void ShowStat()
    {

        statMenu.SetActive(true);

    }

    public void QuitToMenu()
    {

        //_StatScript.indexSignalIcons = 1;
        //UnityThinkGear.StopStream();
        paiseMenu.SetActive(false);
        //startMenu.SetActive(true);
       // backGrnd.SetActive(true);
        gameUI.SetActive(false);

    }

    /*
    public void HowTo()
    {

        howMenu.SetActive(true);

    }

    public void HideHowTo()
    {

        howMenu.SetActive(false);

    }
    */

    public void HideStat()
    {

        statMenu.SetActive(false);

    }

}
