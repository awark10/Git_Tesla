using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Time_UI : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject statMenu;

	// Use this for initialization
	void Start () {

        pauseMenu.SetActive(false);
        statMenu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowPauseMenu();
        }
    }
    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
    }
    public void HidePauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void ShowStatP()
    {
        statMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void HideStatP()
    {
        statMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void Quit()
    {
      //  MainMenuC.connectionDone = true;
        SceneManager.LoadScene(0);
    }

}
