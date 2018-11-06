using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamesMenu : MonoBehaviour {

	public GameObject connectMenu;
	public GameObject gamesMenus;
	public Texture2D[] signalIcons;

	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		if (ThinkGearController.Instance.poorSignalStatus == 0)
		{
			connectMenu.SetActive (true);
			gamesMenus.SetActive (false);
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

	void OnGUI()
	{
		GUILayout.BeginHorizontal();
		GUILayout.Space(Screen.width - 35);
		GUILayout.Label(signalIcons[0]);
		GUILayout.EndHorizontal();
	}
}
