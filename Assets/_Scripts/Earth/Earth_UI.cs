using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Earth_UI : MonoBehaviour {


    public GameObject pauseMenu;
    public GameObject startMenu;
    public GameObject statisticMenu;
    // Use this for initialization
    private void Start()
    {
        startMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {

        pauseMenu.SetActive(true);
        _StatScript.btnGame = 0;
    }
    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        _StatScript.btnGame = 1;
    }
    public void Quit()
    {
        MainMenuC.connectionDone = true;
        SceneManager.LoadScene(0);
    }
    public void ShowStat()
    {
        statisticMenu.SetActive(true);
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
