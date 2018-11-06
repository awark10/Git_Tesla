﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[System.Serializable]

public class MainMenuC : MonoBehaviour {
	
    public GameObject modeMenu;
   // public GameObject mainMenu;

    public GameObject connectMenu;
    public GameObject connectLoader;
    public GameObject statusConnectionImage;
    public Button connectButton;
    public float timeConnection;
    public Text longTimeConnection;
    ThinkGearController controller;
    public bool connecting;
    public bool challenge=false;
    public bool connected;
    public static bool connectionDone;

	public bool ConnectionStatus = false;
	public bool ConnectionInit = false;


	public Texture2D[] signalIcons;
	public static float indexSignalIcons = 1;
	public bool enableAnimation = false;
	private float animationInterval = 0.06f;
	  
	// Use this for initialization
    void Start () {
		
       controller = GameObject.Find("ThinkGear").GetComponent<ThinkGearController>();

		/*
		if (ThinkGearController.Instance.poorSignalStatus == 1 || ThinkGearController.Instance.poorSignalStatus == 2)
        {
			modeMenu.SetActive(true);
			connectMenu.SetActive(false);
			connectLoader.SetActive(false);
        }
        else
        {
			longTimeConnection.text = "Мотивационный текст для старта взаимодействия с приложением";
			connectMenu.SetActive(true);
			modeMenu.SetActive(false);
			connectLoader.SetActive(false);
        }
        */
    }

	// Update is called once per frame
	void Update () {


	}


	void OnGUI()
	{
		GUILayout.BeginHorizontal();
		GUILayout.Space(Screen.width - 35);
		GUILayout.Label(signalIcons[(int)indexSignalIcons]);
		GUILayout.EndHorizontal();
	}

	public void StartBtn()
	{
		enableAnimation = true;

		connectLoader.SetActive(true);
		connectButton.interactable = false;
		longTimeConnection.text = "";
		statusConnectionImage.SetActive(false);

		UnityThinkGear.StartStream();
		StartCoroutine(ConnectionFunc());
	}

	IEnumerator ConnectionFunc()
    {

		while(true){

			if (ThinkGearController.Instance.poorSignalStatus == 1 || ThinkGearController.Instance.poorSignalStatus == 2)
			{

				connectLoader.SetActive (false);
				modeMenu.SetActive (true);
				connectMenu.SetActive (false);
				statusConnectionImage.SetActive (false);

				enableAnimation = false;
				indexSignalIcons = 0;
				timeConnection = 0;
				break;
				 
			} else if (timeConnection > 10)
			{

				longTimeConnection.text = "No connection" + "\r\n" + "Try reconnect";
				connectButton.interactable = true;
				statusConnectionImage.SetActive (true);
				connectLoader.SetActive (false);

				enableAnimation = false;
				indexSignalIcons = 1;
				timeConnection = 0;
				break;

			}
				
			timeConnection ++;
			yield return new WaitForSeconds (1f);
		}

    }
		
    public void LoadTimeGame()
    {
		if (ThinkGearController.Instance.poorSignalStatus == 1 || ThinkGearController.Instance.poorSignalStatus == 2)
        	SceneManager.LoadScene("ClockScene");
    }
    public void LoadEarthGame()
    {
		if (ThinkGearController.Instance.poorSignalStatus == 1 || ThinkGearController.Instance.poorSignalStatus == 2)
        	SceneManager.LoadScene("EarthScene");
    }

	public void Demo()
	{
		connectMenu.SetActive(false);
		modeMenu.SetActive(true);
	}

	public void Challenge()
	{
		modeMenu.SetActive(false);
	}
	public void TrainingGames()
	{
		modeMenu.SetActive(false);
	}
		
	void FixedUpdate()
	{
		if (enableAnimation)
		{
			if (indexSignalIcons >= 4.8)
			{
				indexSignalIcons = 2;
			}
			indexSignalIcons += animationInterval;
		}

	}

}
