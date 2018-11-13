using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimePause : MonoBehaviour {

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
		pauseMenu.SetActive(false);
		gameUI.SetActive(true);
	}
	public void Quit()
	{
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
