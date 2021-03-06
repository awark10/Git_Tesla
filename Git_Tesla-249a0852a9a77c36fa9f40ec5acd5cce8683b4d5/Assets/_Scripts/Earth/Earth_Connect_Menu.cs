﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Earth_Connect_Menu : MonoBehaviour {

	public GameObject gameUI;
	public GameObject connectMenu;

	public Button connectButton;
	public Text longTimeConnection;

	public Texture2D[] signalIcons;
	public float indexSignalIcons = 1;
	private float animationInterval = 0.06f;

	public bool connectionStart = false;
	public int timeConnection = 0;

	void OnEnable ()
	{
		connectionStart = false;
		timeConnection = 0;
		indexSignalIcons = 1;

		connectButton.interactable = true;
	}

	public void StartBtn()
	{
		connectionStart = true;
		connectButton.interactable = false;
		longTimeConnection.text = "";
		timeConnection = 0;
		StartCoroutine(ConnectionFunc());
		//UnityThinkGear.StartStream();
	}

	IEnumerator ConnectionFunc()
	{

		while (true) 
		{
			if (GAME.Instance.isConnected) {

				connectMenu.SetActive (false);
				gameUI.SetActive (true);
				break;

			} 
			else if (timeConnection > 10) 
			{
				longTimeConnection.text = "No connection" + "\r\n" + "Try reconnect";
				connectButton.interactable = true;
				connectionStart = false;
				indexSignalIcons = 1;

				UnityThinkGear.StopStream();
				break;
			}

			timeConnection++;
			yield return new WaitForSeconds (1f);
		}
	}

	void OnGUI()
	{
		print (1);
		GUILayout.BeginHorizontal();
		GUILayout.Space(Screen.width - 35);
		GUILayout.Label(signalIcons[(int)indexSignalIcons]);
		GUILayout.EndHorizontal();
	}

	void FixedUpdate()
	{
		if (connectionStart)
		{
			if (indexSignalIcons >= 4.8)
			{
				indexSignalIcons = 2;
			}
			indexSignalIcons += animationInterval;
		}
	}

	public void Demo()
	{
		GAME.Instance.Attention = 34;
		GAME.Instance.Meditation = 58;
		GAME.Instance.isDemo = true;
		connectMenu.SetActive(false);
		gameUI.SetActive(true);
	}
}
