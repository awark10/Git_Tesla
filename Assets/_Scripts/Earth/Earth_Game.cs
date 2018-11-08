using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Earth_Game : MonoBehaviour {


	ThinkGearController controller;
	// GameObject aura;
	GameObject light50, light60, light80;
	public GameObject aura;
	// ParticleSystem particle;
	//Transform transform;
	//  ParticleSystem.ColorOverLifetimeModule colorModule;
	#region

	[Header("UI elements")]

	//public GameObject connectLoader;
	// public GameObject backGr;
	public GameObject gameUI;

	public Text levelText;
	public Text downTimeText;
	public Text attText;
	public Text medText;
	public Image attSlImage;
	public Image medSlImage;
	// public GameObject startMenu;
	//public Image conImage;
	// public Button connect;
	// public Slider MedSlider;
	// public Slider AtSlider;
	#endregion
	[Header("Signal Elements")]
	// [Range(0, 200)]
	public static int PoorSignal;
	public static float indexSignalIcons = 1;
	private bool enableAnimation = false;
	private float animationInterval = 0.06f;
	[Header("Received Values")]
	[Range(0, 100)]
	public int Attention = 0;
	[Range(0, 100)]
	public int Meditation = 0;



	private float x = 50;
	private float tmpMedSliderVal = 0;
	private float tmpAtSliderVal = 0;
	private bool timerIsActive;

	[Header("Statistics")]
	public float fullTime;
	public float statGameTime = 0;
	public float statMedTime = 0;
	// public float statMed50Time = 0;
	public float statMed60Time = 0;
	public float statMed80Time = 0;
	public float statMedLevel = 0;
	public static int tmpStat = 0;
	public string statStr = "";
	[Header("Game Level Elements")]
	public int gameLevel = 0;
	public float downCounter = 0;
	public float gameTime = 0;

	// Initialization
	void Start()
	{

		controller = GameObject.Find("ThinkGear").GetComponent<ThinkGearController>();
		controller.UpdateAttentionEvent += OnUpdateAttention;
		controller.UpdateMeditationEvent += OnUpdateMeditation;

		// aura = GameObject.Find("Aura");

		light50 = GameObject.Find("lightins50");
		light50.SetActive(false);
		light60 = GameObject.Find("lightins60");
		light60.SetActive(false);
		light80 = GameObject.Find("lightins80");
		light80.SetActive(false);
		// gameUI.SetActive(false);
		//  colorModule = particle.colorOverLifetime;
		// colorModule.color = Color.magenta;

		levelText.text = "";
		downTimeText.text = "";
		// Time.timeScale = 0;
		// MedSlider.value = 0;
		//  AtSlider.value = 0;
		// StartCoroutine(StatusConnection())
	}


	void Update()
	{
		GameLogic();

		UIupdate();

		tmpAtSliderVal = Mathf.Lerp(tmpAtSliderVal, Attention, Time.deltaTime * 5);
		tmpMedSliderVal = Mathf.Lerp(tmpMedSliderVal, Meditation, Time.deltaTime * 5);
		attSlImage.fillAmount = tmpAtSliderVal / 100;
		medSlImage.fillAmount = tmpMedSliderVal / 100;

	}


	void GameLogic()
	{

		// Game start
		if (Meditation <50 && Attention<50)
			StopGame();

		if (Meditation >=50 && Attention>=50)
			gameTime += Time.deltaTime;

		// Level 1
		if (gameLevel == 0 && Meditation >= 50 && Attention >= 50 && gameTime > 5)
		{
			gameLevel++;
			levelText.text = "Level 1";
			downCounter = 8;
		}
		else if (gameLevel == 1 && Meditation < 50 && gameTime < 10)
		{
			StopGame();
		}
		else if (gameLevel == 1 && Meditation < 60 && gameTime > 10)
		{
			LighProcessing(1);
			StopGame();
		}
		else if (gameLevel == 1 && Meditation >= 60 && gameTime > 10)
		{
			LighProcessing(1);
		}

		// Level 2
		if (gameLevel == 1 && Meditation >= 60 && gameTime > 10)
		{
			gameLevel++;
			levelText.text = "Level 2";
			downCounter = 8;
		}
		else if (gameLevel == 2 && Meditation < 60 && gameTime < 15)
		{
			StopGame();
		}
		else if (gameLevel == 2 && Meditation < 80 && gameTime > 15)
		{
			LighProcessing(2);
			StopGame();
		}
		else if (gameLevel == 2 && Meditation >= 80 && gameTime > 15)
		{
			LighProcessing(2);
		}

		// Level 3
		if (gameLevel == 2 && Meditation >= 80 && gameTime > 15)
		{

			gameLevel++;
			levelText.text = "Level 3";

			downCounter = 8;
		}
		else if (gameLevel == 3 && Meditation < 80 && gameTime < 20)
		{

			StopGame();

		}
		else if (gameLevel == 3 && Meditation >= 80 && gameTime > 20)
		{
			LighProcessing(3);
		}

		// Level 4
		if (gameLevel == 3 && Meditation >= 80 && gameTime > 20)
		{

			gameLevel++;
			levelText.text = "";

		}
		else if (gameLevel == 4 && Meditation < 70 && gameTime < 30)
		{

			gameTime = 20;

		}
		else if (gameLevel == 4 && Meditation >= 70 && gameTime > 30)
		{
			LighProcessing(3);
			gameTime = 20;
		}
		LighProcessing(0);
	}
	public static int btnGame = 0;


	void UIupdate()
	{
		attText.text = "" + Attention+"%";
		medText.text = "" + Meditation+"%";

		downTimeText.text = "";

		if (gameLevel != 0 && gameLevel != 4)
		{
			downCounter -= Time.deltaTime;
			int td = (int)downCounter;
			downTimeText.text = "" + td;
		}

		if (btnGame == 1)
		{
			if (PoorSignal == 0)
			{
				// backGr.SetActive(false);
				indexSignalIcons = 0;
				enableAnimation = false;

				//  startMenu.SetActive(false);
				// connectLoader.SetActive(false);
				btnGame = 0;
				gameUI.SetActive(true);
			}
			if (!enableAnimation && PoorSignal != 200 && PoorSignal != 0)
			{
				indexSignalIcons = 2;
				enableAnimation = true;
				// startMenu.SetActive(false);
				// connectLoader.SetActive(false);
				// backGr.SetActive(false);
				btnGame = 0;
				gameUI.SetActive(true);

			}

		}

		if (PoorSignal == 200 && btnGame==0 )
		{

			//  backGr.SetActive(true);
			// Time.timeScale = 1;
			indexSignalIcons = 1;
			enableAnimation = false;
			//  startMenu.SetActive(true);
			// connect.interactable = true;
			gameUI.SetActive(false);
			StopGame();
		}
		else if (PoorSignal == 200 && btnGame==1)
		{

			//   backGr.SetActive(true);
			// Time.timeScale = 1;
			indexSignalIcons = 1;
			enableAnimation = false;
			//  startMenu.SetActive(true);
			//  connect.interactable = false;
			gameUI.SetActive(false);
			StopGame();
		}

	}

	void StopGame()
	{
		gameTime = 0;
		gameLevel = 0;
		levelText.text = "";
		float t = Mathf.Lerp(255f, 0f, Time.deltaTime);
		downTimeText.color = new Color(255, 255, 255, t);
		downTimeText.text = "";

	}

	float lockTime = 0f;
	int localLock = 0;

	void LighProcessing(int i)
	{ 

		if (i == 0 && localLock == 0)
		{
			lockTime = Time.time + 2;
			light50.SetActive(false);
			light60.SetActive(false);
			light80.SetActive(false);
		}

		if (i == 1)
		{
			light50.SetActive(true);
			localLock = 1;
		}
		else if (localLock == 1 && Time.time > lockTime)
		{
			localLock = 0;
		}

		if (i == 2)
		{
			light60.SetActive(true);
			localLock = 2;
		}
		else if (localLock == 2 && Time.time > lockTime)
		{
			localLock = 0;
		}

		if (i == 3)
		{
			light80.SetActive(true);
			localLock = 3;
		}
		else if (localLock == 3 && Time.time > lockTime)
		{
			localLock = 0;
		}
	}


	void OnUpdateAttention(int value)
	{ 
		Attention = value;
	}
	void OnUpdateMeditation(int value)
	{
		Meditation = value;
		// statistic part
		if(value>0)
			statMedLevel = (statMedLevel + value) / 2;
	}
}
