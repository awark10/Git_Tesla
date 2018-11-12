using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Earth_Pause_Menu : MonoBehaviour {

    public GameObject pauseMenu;
	public GameObject gameUI;

    //public GameObject startMenu;
    public GameObject statisticMenu;
    // Use this for initialization
    private void Start()
    {
        //startMenu.SetActive(true);
        //pauseMenu.SetActive(false);
        //statisticMenu.SetActive(false);
    }

	void OnEnable (){

		pauseMenu.SetActive(true);
		gameUI.SetActive(false);
	}

    public void ContinueGame()
    {
		Time.timeScale = 1;
        pauseMenu.SetActive(false);
		gameUI.SetActive(true);
    }
    public void Quit()
    {
		Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void ShowStat()
    {
        statisticMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void HideStartMenu()
    {
        //startMenu.SetActive(false);
    }
    public void HideStat()
    {
        statisticMenu.SetActive(false);
    }
}
