using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors_Game : MonoBehaviour {
  //  public GameObject gameUI;
    public GameObject connectMenu;
    public GameObject pauseMenu;
    Color randomColorText;
    public string randomText;
    
    void Start ()
    {
        pauseMenu.SetActive(false);
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {  
        pauseMenu.SetActive(true);
    }
}
