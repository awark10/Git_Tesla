using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorsPause : MonoBehaviour {
    public GameObject pauseMenu;
    public GameObject statisticMenu;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ContinueGame();
            }
        }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
       // gameUI.SetActive(true);
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
    public void HideStat()
    {
        statisticMenu.SetActive(false);
        //gameUI.SetActive(true);
    }
}
