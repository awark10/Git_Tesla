using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamesMenu : MonoBehaviour {

	public GameObject connectMenu;
	public GameObject gamesMenus;

	void OnEnable () {

		gamesMenus.SetActive (true);
	}

	void Update () {

		if (!GDATA.Instance.isDemo){
			
			if (!GDATA.Instance.isSignal)
			{
				connectMenu.SetActive (true);
				gamesMenus.SetActive (false);
			}
        }
    }

	public void LoadTimeGame()
	{
		SceneManager.LoadScene("ClockScene");
	}

	public void LoadEarthGame()
	{
		SceneManager.LoadScene("EarthScene");
	}
}
