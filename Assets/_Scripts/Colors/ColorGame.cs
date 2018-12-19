﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorGame : MonoBehaviour {

	public GameObject gameUI;
	public GameObject connectMenu;
	public GameObject pauseMenu;

	public Text attText;
	public Text medText;
	public Image attSlImage;
	public Image medSlImage;

	[Header("Received Values")]
	[Range(0, 100)]
	public int Attention = 0;
	[Range(0, 100)]
	public int Meditation = 0;

	private float tmpMedSliderVal = 0;
	private float tmpAtSliderVal = 0;

	// Use this for initialization
	/*void Start () {
		
	}*/

	void Update()
	{
		if (!CONNECTOR.Instance.isDemo) 
		{
			Attention = CONNECTOR.Instance.Attention;
			Meditation = CONNECTOR.Instance.Meditation;
		}
		else 
		{
			Attention = 46;
			Meditation = 75;
		}

		UIupdate ();

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			ShowPauseMenu();
		}
	}

	public void ShowPauseMenu()
	{
		pauseMenu.SetActive(true);
		gameUI.SetActive(false);
	}

	void GameLogic(){


	}

	void UIupdate() {

		attText.text = "" + Attention+"%";
		medText.text = "" + Meditation+"%";

		tmpAtSliderVal = Mathf.Lerp(tmpAtSliderVal, Attention, Time.deltaTime * 5);
		tmpMedSliderVal = Mathf.Lerp(tmpMedSliderVal, Meditation, Time.deltaTime * 5);
		attSlImage.fillAmount = tmpAtSliderVal / 100;
		medSlImage.fillAmount = tmpMedSliderVal / 100;
	}
}

